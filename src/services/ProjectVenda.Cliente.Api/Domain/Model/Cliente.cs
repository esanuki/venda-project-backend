using ProjectVenda.Cliente.Api.Domain.Validation;
using ProjectVenda.Core.DomainObjects;
using System;

namespace ProjectVenda.Cliente.Api.Domain.Model
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Guid? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public override bool IsValid()
        {
            return new ClienteValidation().Validate(this).IsValid;
        }
    }
}
