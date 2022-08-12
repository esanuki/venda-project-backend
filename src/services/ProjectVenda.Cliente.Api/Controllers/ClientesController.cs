
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Cliente.Api.Domain.Interop.ViewModel;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Notificator;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientesController(INotificator notificator, IMediator mediator, IMapper mapper) : base(notificator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(CustomResponse(true));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ClienteCreateViewModel cliente)
        {
            var command = _mapper.Map<InserirClienteCommand>(cliente);

            await _mediator.Send(command);

            return CustomResponse(true);
        }
    }
}
