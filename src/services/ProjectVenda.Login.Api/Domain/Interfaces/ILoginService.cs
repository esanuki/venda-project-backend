using Microsoft.AspNetCore.Identity;
using ProjectVenda.Login.Api.Domain.Models;
using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
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
