using FluentValidation;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Login.Api.Application.Comand;

namespace ProjectVenda.Login.Api.Domain.Validations
{
    public class RegistrarUsuarioValidation : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioValidation()
        {
            RuleFor(ru => ru.Email)
                .NotEmpty().WithMessage("O e-mail não foi informado")
                .Must(Email.ValidarEmail).WithMessage("O e-mail informado não é valido");

            RuleFor(ru => ru.Senha)
                .NotEmpty().WithMessage("A senha não foi informada.")
                .MinimumLength(3).WithMessage("A senha deve ter pelo menos 3 caracteres")
                .MaximumLength(15).WithMessage("A senha deve ter no máximo 15 caracteres");
        }
    }
}
