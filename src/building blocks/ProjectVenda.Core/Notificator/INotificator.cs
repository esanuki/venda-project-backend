using ProjectVenda.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Notificator
{
    public interface INotificator
    {
        bool ExistsNotification();
        void Handle(Notification notification);
        IList<Notification> GetNotifications();
        void Clear();
    }
}
