using ProjectVenda.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Notificator
{
    public class Notificator : INotificator
    {
        private IList<Notification> _notifications = new List<Notification>();

        public void Clear()
        {
            _notifications = new List<Notification>();
        }

        public bool ExistsNotification()
        {
            return _notifications.Any();
        }

        public IList<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
