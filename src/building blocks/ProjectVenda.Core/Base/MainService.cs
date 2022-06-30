using ProjectVenda.Core.Notificator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Base
{
    public class MainService
    {
        protected INotificator _notificator;

        public MainService(INotificator notificator)
        {
            _notificator = notificator;
        }
    }
}
