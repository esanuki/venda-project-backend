using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Login.Api.Application.Comand;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Controllers
{
    [Route("api/login")]
    public class LoginController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public LoginController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(UsuarioRegistroViewModel usuarioRegistro)
        {
            var usuarioCommand = new RegistrarUsuarioCommand(usuarioRegistro.Email, usuarioRegistro.Senha);

            if (!usuarioCommand.IsValid()) CustomResponse();
            
            return CustomResponse(await _mediator.SendCommand(usuarioCommand));
        }
    }
}
