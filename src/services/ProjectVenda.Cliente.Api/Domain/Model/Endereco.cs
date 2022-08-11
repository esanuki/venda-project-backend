using ProjectVenda.Cliente.Api.Domain.Validation;
using ProjectVenda.Core.DomainObjects;
using System.Security.Permissions;

namespace ProjectVenda.Cliente.Api.Domain.Model
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public override bool IsValid()
        {
            return new EnderecoValidation().Validate(this).IsValid;
        }
    }
}
