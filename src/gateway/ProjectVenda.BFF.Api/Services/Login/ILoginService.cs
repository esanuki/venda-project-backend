using Microsoft.AspNetCore.Identity;
using ProjectVenda.Core.Interop.Login;
using ProjectVenda.Core.Response;
using System.Threading.Tasks;

namespace ProjectVenda.BFF.Api.Services.Login
{
    public interface ILoginService
    {
        Task<ResponseResult<LoginResponseDto>> Register(IdentityUser user, string senha);
        Task<ResponseResult<LoginResponseDto>> Login(LoginViewModel login);
    }
}
