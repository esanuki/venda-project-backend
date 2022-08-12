using System;

namespace ProjectVenda.Cliente.Api.Domain.Interop.ViewModel
{
    public class ClienteUpdateViewModel
    {
        public decimal Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
