using FluentValidation.Results;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.DomainObjects
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;
        protected INotificator _notificator;

        public CommandHandler(INotificator notificator)
        {
            ValidationResult = new ValidationResult();
            _notificator = notificator;
        }

        protected void AddErrors(string message)
        {
            _notificator.Handle(new Notification(message));
        }

    }
}
