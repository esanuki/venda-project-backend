using ProjectVenda.Cliente.Api.Domain.Interop.ViewModel;
using ProjectVenda.Cliente.Api.Domain.Validation;
using ProjectVenda.Core.DomainObjects;
using System;

namespace ProjectVenda.Cliente.Api.Application.Comand
{
    public class InsertClienteCommand : Command
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }

    }
}
