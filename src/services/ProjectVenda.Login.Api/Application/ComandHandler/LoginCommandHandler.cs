using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Comand;
using ProjectVenda.Login.Api.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.ComandHandler
{
    public class LoginCommandHandler : CommandHandler,
        IRequestHandler<RegistrarUsuarioCommand, bool>
    {
        private ILoginService _loginService;
        public LoginCommandHandler(INotificator notificator, ILoginService loginService) : base(notificator)
        {
            _loginService = loginService;
        }

        public async Task<bool> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                request.ValidationResult.Errors.ForEach( x => AddErrors(x.ErrorMessage));
                return false;
            }

            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _loginService.Register(user, request.Senha);

            if (!result.Succeeded)
                result.Errors.ToList().ForEach(x => AddErrors(x.Description));

            return  await Task.FromResult(true);
        }

    }
}
