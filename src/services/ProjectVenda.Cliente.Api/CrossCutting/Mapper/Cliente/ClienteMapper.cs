using AutoMapper;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Cliente.Api.Domain.Interop.Dto;
using ProjectVenda.Cliente.Api.Domain.Interop.ViewModel;

namespace ProjectVenda.Cliente.Api.CrossCutting.Mapper.Cliente
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Domain.Model.Cliente, ClienteDto>();
            CreateMap<ClienteCreateViewModel, InserirClienteCommand>();
            CreateMap<InserirClienteCommand, Domain.Model.Cliente>();
            CreateMap<ClienteUpdateViewModel, Domain.Model.Cliente>();
        }
    }
}
