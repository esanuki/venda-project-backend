using AutoMapper;
using ProjectVenda.Cliente.Api.Domain.Interop.Dto;
using ProjectVenda.Cliente.Api.Domain.Interop.ViewModel;
using ProjectVenda.Cliente.Api.Domain.Model;

namespace ProjectVenda.Cliente.Api.CrossCutting.Mapper.Cliente
{
    public class EnderecoMapper : Profile
    {
        public EnderecoMapper()
        {
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<Endereco, EnderecoDto>();
        }
    }
}
