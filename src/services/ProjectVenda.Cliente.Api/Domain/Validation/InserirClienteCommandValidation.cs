using FluentValidation;
using ProjectVenda.Cliente.Api.Application.Comand;
using ProjectVenda.Core.DomainObjects;

namespace ProjectVenda.Cliente.Api.Domain.Validation
{
    public class InserirClienteCommandValidation : AbstractValidator<InserirClienteCommand>
    {
        public InserirClienteCommandValidation()
        {
            RuleFor(c => c.Nome)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .Length(3, 60).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cpf)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .Length(11, 11).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(c => CpfValidacao.Validate(c.Cpf))
                .Equal(true).WithMessage("O cpf é inválido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .EmailAddress().WithMessage("Não é e-mail válido!")
                .Length(6, 60).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
