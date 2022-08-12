namespace ProjectVenda.Cliente.Api.Domain.Interop.Dto
{
    public class EnderecoDto
    {
        public decimal Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
