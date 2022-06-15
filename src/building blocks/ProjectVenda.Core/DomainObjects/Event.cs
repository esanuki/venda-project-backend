using MediatR;

namespace ProjectVenda.Core.DomainObjects
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
