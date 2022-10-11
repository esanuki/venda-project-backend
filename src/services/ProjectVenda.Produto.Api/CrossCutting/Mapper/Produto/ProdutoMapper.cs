using AutoMapper;
using ProjectVenda.Produto.Api.Domain.Interop.Dto;

namespace ProjectVenda.Produto.Api.CrossCutting.Mapper.Produto
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Domain.Model.Produto, ProdutoDto>();
        }
    }
}
