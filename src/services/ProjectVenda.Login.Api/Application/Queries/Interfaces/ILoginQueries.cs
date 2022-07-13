using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.Queries.Interfaces
{
    public interface ILoginQueries
    {
        Task<LoginResponseDto> Login(LoginViewModel loginViewModel);
        Task<LoginResponseDto> RefreshToken(string refreshToken);
    }
}
