using ProjectVenda.Core.Base;
using ProjectVenda.Core.Notificator;

namespace ProjectVenda.Core.DomainObjects
{
    public abstract class Message
    {
        public string MessageType { get; set; }

        public Message() 
        {
            MessageType = GetType().Name;
        }
    }
}
