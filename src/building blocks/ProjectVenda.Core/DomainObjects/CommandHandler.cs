using FluentValidation.Results;

namespace ProjectVenda.Core.DomainObjects
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddErrors(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

    }
}
