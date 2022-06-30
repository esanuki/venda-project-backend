using ProjectVenda.Core.DomainObjects;

namespace ProjectVenda.Core.Helpers
{
    public static class StringsHelper
    {
        public static bool EmailValido(this string email)
        {
            return Email.ValidarEmail(email);
        }
    }
}
