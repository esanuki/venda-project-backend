
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Notificator;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : MainController
    {
        public ClientesController(INotificator notificator) : base(notificator)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(CustomResponse(true));
        }
    }
}
