using AutoMapper;
using MediatR;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Cliente.Api.Persistance.Repository.Cliente;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Notificator;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Application.ComandHandler
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<InserirClienteCommand, bool>
    {
        private IClienteRepository _clienteRepository;
        private IMapper _mapper;

        public ClienteCommandHandler(
            INotificator notificator, 
            IClienteRepository clienteRepository, 
            IMapper mapper) : base(notificator)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(InserirClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                request.ValidationResult.Errors.ForEach(x => AddErrors(x.ErrorMessage));
                return false;
            }

            return await Task.FromResult(true);
        }
    }
}
