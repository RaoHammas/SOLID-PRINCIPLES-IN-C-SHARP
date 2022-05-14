using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_PRINCIPLES.D
{
    public class Email
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public void SendEmail()
        {
            //Send email
        }
    }

    public class SMS
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public void SendSMS()
        {
            //Send sms
        }
    }

    public class Notification
    {
        private Email _email;
        private SMS _sms;

        public Notification()
        {
            // this is making Notification class which is high level depend on
            // low level classes sms and email

            _email = new Email(); // tight coupling
            _sms = new SMS(); // tight coupling
        }

        public void Send()
        {
            _email.SendEmail();
            _sms.SendSMS();
        }

    }
}