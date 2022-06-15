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
