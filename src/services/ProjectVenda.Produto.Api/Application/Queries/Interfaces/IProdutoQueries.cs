using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProjectVenda.Produto.Api.Domain.Interop.Dto;

namespace ProjectVenda.Produto.Api.Application.Queries.Interfaces
{
    public interface IProdutoQueries
    {
        Task<IEnumerable<ProdutoDto>> GetAll();
        Task<ProdutoDto> GetById(Guid id);
    }
}
