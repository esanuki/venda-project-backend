using FluentValidation.Results;
using MediatR;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Login.Api.Application.Comand;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectVenda.Login.Api.Application.ComandHandler
{
    public class LoginCommandHandler : CommandHandler,
        IRequestHandler<RegistrarUsuarioCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            AddErrors("Erro aqui e agora");

            return  await Task.FromResult(ValidationResult);
        }
    }
}
