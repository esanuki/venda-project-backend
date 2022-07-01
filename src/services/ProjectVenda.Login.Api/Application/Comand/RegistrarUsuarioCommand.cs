
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Login.Api.Domain.Validations;

namespace ProjectVenda.Login.Api.Application.Comand
{
    public class RegistrarUsuarioCommand : Command
    {
        public RegistrarUsuarioCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarUsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
