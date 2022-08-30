using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectVenda.Core.Base;
using ProjectVenda.Core.Configuration;
using ProjectVenda.Core.Interop.Login;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Core.User;
using ProjectVenda.Login.Api.Domain.Interfaces;
using ProjectVenda.Login.Api.Domain.Models;
using ProjectVenda.Login.Api.Repository.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Services
{
    public class LoginService : MainService, ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUser _user;
        private readonly ApplicationDbContext _context;
        public LoginService(
            INotificator notificator,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUser user,
            ApplicationDbContext context) : base(notificator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _user = user;
            _context = context;
        }

        public async Task<SignInResult> Login(LoginViewModel login)
        {
            return await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, true);
        }

        public async Task<IdentityResult> Register(IdentityUser user, string senha)
        {
            return await _userManager.CreateAsync(user, senha);
        }

        public async Task<LoginResponseDto> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await GetClaims(claims, user);
            var token = GetToken(identityClaims);
            var refreshToken = await GenerateRefreshToken(email);

            return GetLoginResponse(token, user, claims, refreshToken);

        }

        public async Task<RefreshToken> GetRefreshToken(Guid token)
        {
            var refreshToken = await _context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(r => r.Token.Equals(token));

            return refreshToken != null && refreshToken.ExpirationDate.ToLocalTime() > DateTime.Now ? refreshToken : null;
        }

        #region Metodos Privados
        private async Task<ClaimsIdentity> GetClaims(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64));

            userRoles.ToList().ForEach(x => claims.Add(new Claim("role", x)));

            var identityClaims = new ClaimsIdentity(claims);
            //identityClaims.AddClaims(claims);

            return identityClaims;

        }

        private string GetToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSettings.ChaveSecreta);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenSettings.Emissor,
                Audience = TokenSettings.Audiencia,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private async Task<RefreshToken> GenerateRefreshToken(string email)
        {
            var refreshToken = new RefreshToken
            {
                Email = email,
                ExpirationDate = DateTime.UtcNow.AddHours(2),
            };

            _context.RefreshTokens.RemoveRange(_context.RefreshTokens.Where(u => u.Email.Equals(email)));
            await _context.RefreshTokens.AddAsync(refreshToken);

            await _context.SaveChangesAsync();

            return refreshToken;
        }

        private LoginResponseDto GetLoginResponse(string token, IdentityUser user, IEnumerable<Claim> claims, RefreshToken refreshToken)
        {
            return new LoginResponseDto
            {
                AccessToken = token,
                RefreshToken = refreshToken.Token,
                ExpiresIn = TimeSpan.FromHours(1).TotalSeconds,
                Login = new LoginDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimsDto { Type = c.Type, Value = c.Value })
                }
            };
        }
        #endregion
    }
}
