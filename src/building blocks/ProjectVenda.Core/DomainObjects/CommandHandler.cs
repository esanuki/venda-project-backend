using FluentValidation.Results;
using ProjectVenda.Core.Base;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.DomainObjects
{
    public class CommandHandler : Main
    {
        protected ValidationResult ValidationResult;

        public CommandHandler(INotificator notificator) : base(notificator)
        {
            ValidationResult = new ValidationResult();
        }

    }
}
