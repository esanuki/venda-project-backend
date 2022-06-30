using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Comand;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Controllers
{
    [Route("api/login")]
    public class LoginController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public LoginController(
            INotificator notificator, 
            IMediatorHandler mediator) : base(notificator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(LoginViewModel usuarioRegistro)
        {
            var usuarioCommand = new RegistrarUsuarioCommand(usuarioRegistro.Email, usuarioRegistro.Senha);

            if (!usuarioCommand.IsValid()) CustomResponse(usuarioCommand.ValidationResult);
            
            return CustomResponse(await _mediator.SendCommand(usuarioCommand));
        }

        public async Task<ActionResult> Login(LoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return null;
        }
    }
}
