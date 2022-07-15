using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Mediator;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Login.Api.Application.Comand;
using ProjectVenda.Login.Api.Application.Queries.Interfaces;
using ProjectVenda.Login.Api.Interop.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Controllers
{
    [Route("api/login")]
    public class LoginController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly ILoginQueries _loginQueries;

        public LoginController(
            INotificator notificator,
            IMediatorHandler mediator,
            ILoginQueries loginQueries) : base(notificator)
        {
            _mediator = mediator;
            _loginQueries = loginQueries;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Register(LoginViewModel usuarioRegistro)
        {
            var usuarioCommand = new RegistrarUsuarioCommand(usuarioRegistro.Email, usuarioRegistro.Senha);

            if (!usuarioCommand.IsValid()) CustomResponse(usuarioCommand.ValidationResult);
            
            return CustomResponse(await _mediator.SendCommand(usuarioCommand));
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Authenticate(LoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _loginQueries.Login(usuarioLogin);

            if (_notificator.ExistsNotification()) return CustomResponse();

            return CustomResponse(result);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
        {
            var token = await _loginQueries.RefreshToken(refreshToken);

            if (_notificator.ExistsNotification()) return CustomResponse();

            return CustomResponse(token);
        }
    }
}
