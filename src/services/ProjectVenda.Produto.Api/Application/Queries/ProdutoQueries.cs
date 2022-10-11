using AutoMapper;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Produto.Api.Application.Queries.Interfaces;
using ProjectVenda.Produto.Api.Domain.Interop.Dto;
using ProjectVenda.Produto.Api.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVenda.Produto.Api.Application.Queries
{
    public class ProdutoQueries : Core.DomainObjects.Queries, IProdutoQueries
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoQueries(
            INotificator notificator, 
            IProdutoRepository produtoRepository, 
            IMapper mapper) : base(notificator)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAll()
        {
            var result = await _produtoRepository.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDto>>(result);    
        }

        public async Task<ProdutoDto> GetById(Guid id)
        {
            var result = await _produtoRepository.GetById(id);
            return _mapper.Map<ProdutoDto>(result);
        }
    }
}
