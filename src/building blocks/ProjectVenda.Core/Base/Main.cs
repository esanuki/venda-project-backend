using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.Base
{
    public abstract class Main
    {
        protected INotificator _notificator;

        protected Main(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void AddErrors(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}
