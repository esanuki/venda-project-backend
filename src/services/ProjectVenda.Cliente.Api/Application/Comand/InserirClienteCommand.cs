using ProjectVenda.Cliente.Api.Domain.Validation;
using ProjectVenda.Core.DomainObjects;
using System;

namespace ProjectVenda.Cliente.Api.Application.Comand
{
    public class InserirClienteCommand : Command
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new InserirClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
