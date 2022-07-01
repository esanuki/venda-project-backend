using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.Base
{
    public class MainService : Main
    {

        public MainService(INotificator notificator) : base(notificator)
        {
        }

    }
}
