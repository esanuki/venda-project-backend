using Microsoft.AspNetCore.Identity;
using ProjectVenda.Core.Base;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Domain.Interfaces;
using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Services
{
    public class LoginService : MainService, ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginService(
            INotificator notificator,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager) : base(notificator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

            return null;

        }

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
    }
}
