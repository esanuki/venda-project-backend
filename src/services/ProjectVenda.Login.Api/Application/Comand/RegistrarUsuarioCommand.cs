
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Login.Api.Domain.Validations;

namespace ProjectVenda.Login.Api.Application.Comand
{
    public class RegistrarUsuarioCommand : Command
    {
        public RegistrarUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarUsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
