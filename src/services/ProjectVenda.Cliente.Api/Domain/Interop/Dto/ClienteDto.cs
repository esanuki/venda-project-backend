using System;

namespace ProjectVenda.Cliente.Api.Domain.Interop.Dto
{
    public class ClienteDto
    {
        public decimal Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
