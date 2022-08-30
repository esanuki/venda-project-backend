using ProjectVenda.Core.Interop.Login;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.Queries.Interfaces
{
    public interface ILoginQueries
    {
        Task<LoginResponseDto> Login(LoginViewModel loginViewModel);
        Task<LoginResponseDto> RefreshToken(string refreshToken);
    }
}
