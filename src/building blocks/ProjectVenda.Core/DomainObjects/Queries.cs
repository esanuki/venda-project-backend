using FluentValidation.Results;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.DomainObjects
{
    public class Queries
    {
        protected INotificator _notificator;

        public Queries(INotificator notificator)
        {
            _notificator = notificator;
        }
    }
}
