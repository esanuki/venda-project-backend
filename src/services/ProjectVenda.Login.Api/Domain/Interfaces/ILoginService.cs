using Microsoft.AspNetCore.Identity;
using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<IdentityResult> Register(IdentityUser user, string senha);
        Task<LoginResponseDto> Login(LoginViewModel login);
    }
}
