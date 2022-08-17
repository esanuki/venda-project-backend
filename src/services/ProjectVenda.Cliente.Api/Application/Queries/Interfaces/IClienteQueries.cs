using ProjectVenda.Cliente.Api.Domain.Interop.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Application.Queries.Interfaces
{
    public interface IClienteQueries
    {
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDto> GetById(Guid id);

    }
}
