namespace SOLID_PRINCIPLES.D
{
    /// <summary>
    /// DEPENDENCY INVERSION PRINCIPLE
    /// High level classes should not depend on low level classes
    /// both should depend on abstraction and abstraction should not depend on details
    /// details should depend on abstraction
    /// </summary>
    public interface ISender
    {
        void Send();
    }

    public class EmailNew : ISender
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public void Send()
        {
            //Send email
        }
    }

    public class SMSNew : ISender
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public void Send()
        {
            //Send sms
        }
    }

    public class NotificationNew
    {
        private readonly ICollection<ISender> _senders;

        public NotificationNew(ICollection<ISender> senders)
        {
            _senders = senders;
        }

        public void Send()
        {
            foreach (var sender in _senders)
            {
                sender.Send();
            }
        }
    }
}