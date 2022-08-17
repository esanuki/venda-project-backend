
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Cliente.Api.Application.Queries.Interfaces;
using ProjectVenda.Cliente.Api.Domain.Interop.ViewModel;
using ProjectVenda.Core.Controllers;
using ProjectVenda.Core.Notificator;
using System;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClientesController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteQueries _clienteQueries;

        public ClientesController(
            INotificator notificator, 
            IMediator mediator, 
            IMapper mapper, 
            IClienteQueries clienteQueries) : base(notificator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clienteQueries = clienteQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteQueries.GetAll();

            if (result is null) AddError("Nenhum resultado encontrado");

            return CustomResponse(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _clienteQueries.GetById(id);

            if (result is null) AddError("Nenhum resultado encontrado");

            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCreateViewModel cliente)
        {
            var command = _mapper.Map<InsertClienteCommand>(cliente);

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteUpdateViewModel cliente)
        {
            var command = _mapper.Map<UpdateClienteCommand>(cliente);

            var result = await _mediator.Send(command);

            return CustomResponse(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteClienteCommand(id);

            var result = await _mediator.Send(command);

            return CustomResponse(result);    
        }
    }
}
