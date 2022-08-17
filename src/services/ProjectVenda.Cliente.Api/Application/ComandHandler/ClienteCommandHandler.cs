using AutoMapper;
using MediatR;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Cliente.Api.Persistance.Repository.Cliente;
using ProjectVenda.Core.Data;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Notificator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectVenda.Cliente.Api.Application.ComandHandler
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<InsertClienteCommand, bool>,
        IRequestHandler<UpdateClienteCommand, bool>,
        IRequestHandler<DeleteClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteCommandHandler(
            INotificator notificator,
            IClienteRepository clienteRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(notificator)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InsertClienteCommand request, CancellationToken cancellationToken)
        {
            
            var cliente = _mapper.Map<Domain.Model.Cliente>(request);

            if (!await IsValid(cliente)) return false;

            await _clienteRepository.Save(cliente);

            await _unitOfWork.Commit();


            return true;
        }

        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Domain.Model.Cliente>(request);

            if (!await IsValid(cliente)) return false;

            await _clienteRepository.Update(cliente);

            await _unitOfWork.Commit();

            return true;
        }

        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetById(request.Id);

            if (cliente is null)
            {
                AddErrors("Registro não encontrado");
                return false;
            }

            await _clienteRepository.Delete(cliente);

            await _unitOfWork.Commit();

            return true;
        }

        private async Task<bool> IsValid(Domain.Model.Cliente cliente)
        {
            if (!cliente.IsValid())
            {
                cliente.ValidationResult.Errors.ForEach(x => AddErrors(x.ErrorMessage));
                return false;
            }

            if (cliente.Endereco is not null)
            {
                if (!cliente.Endereco.IsValid())
                {
                    cliente.Endereco.ValidationResult.Errors.ForEach(x => AddErrors(x.ErrorMessage));
                    return false;
                }
            }

            return await Task.FromResult(true);
        }
    }
}
