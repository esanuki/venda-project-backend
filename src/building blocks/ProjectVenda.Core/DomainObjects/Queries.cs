using FluentValidation.Results;
using ProjectVenda.Core.Base;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.DomainObjects
{
    public class Queries : Main
    {
        public Queries(INotificator notificator) : base(notificator)
        {
        }       
    }
}
