using Microsoft.AspNetCore.Identity;
using ProjectVenda.Core.Interop.Login;
using ProjectVenda.Login.Api.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<IdentityResult> Register(IdentityUser user, string senha);
        Task<SignInResult> Login(LoginViewModel login);
        Task<LoginResponseDto> GenerateToken(string email);
        Task<RefreshToken> GetRefreshToken(Guid token);
    }
}
