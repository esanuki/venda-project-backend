using Microsoft.AspNetCore.Identity;
using ProjectVenda.Core.Base;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Domain.Interfaces;
using ProjectVenda.Login.Api.Interop.Dto;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Services
{
    public class LoginService : MainService, ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public LoginService(
            INotificator notificator, 
            UserManager<IdentityUser> userManager) : base(notificator)
        {
            _userManager = userManager;
        }

        public Task<LoginResponseDto> Login(LoginViewModel login)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> Register(IdentityUser user, string senha)
        {
            return await _userManager.CreateAsync(user, senha);
        }
    }
}
