using System.ComponentModel.DataAnnotations;

namespace ProjectVenda.Core.Interop.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O {0} é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "A {0} deve ter entre {2} e {1}", MinimumLength = 3)]
        public string Senha { get; set; }

    }
}
