using Microsoft.AspNetCore.Mvc;
using ProjectVenda.BFF.Api.Services.Login;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Interop.Login;
using ProjectVenda.Core.Notificator;
using System.Threading.Tasks;

namespace ProjectVenda.BFF.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : MainController
    {
        private readonly ILoginService _service;
        public LoginController(INotificator notificator, ILoginService service) : base(notificator)
        {
            _service = service;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var retorno = await _service.Login(loginViewModel);

            return CustomResponse(retorno.Data);
        }
    }
}
