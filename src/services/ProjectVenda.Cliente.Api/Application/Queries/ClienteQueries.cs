using AutoMapper;
using ProjectVenda.Cliente.Api.Application.Queries.Interfaces;
using ProjectVenda.Cliente.Api.Domain.Interop.Dto;
using ProjectVenda.Cliente.Api.Persistance.Repository.Cliente;
using ProjectVenda.Core.Notificator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Application.Queries
{
    public class ClienteQueries : Core.DomainObjects.Queries, IClienteQueries
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteQueries(
            INotificator notificator, 
            IClienteRepository clienteRepository, 
            IMapper mapper) : base(notificator)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var result = await _clienteRepository.GetAll();

            return _mapper.Map<IEnumerable<ClienteDto>>(result);
        }

        public async Task<ClienteDto> GetById(Guid id)
        {
            var result = await _clienteRepository.GetById(id);

            return _mapper.Map<ClienteDto>(result);
        }
    }
}
