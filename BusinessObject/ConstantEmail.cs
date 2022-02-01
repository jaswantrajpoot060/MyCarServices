using System.Net.Mail;

namespace BusinessObject
{
    public class ConstantEmail : BaseObject
    {

        //public static void SendMail(string mailto, string from, string Subject, string body)
        //{

        //    string mailbody = body;
        //    MailAddress MailFrom = new MailAddress(from, "Edubright Institute Of Management Technology Pvt. Ltd");
        //    MailAddress MailTo = new MailAddress(mailto, "");
        //    MailMessage mailmessage = new MailMessage(MailFrom, MailTo);

        //    mailmessage.To.Add(mailto);
        //    mailmessage.Subject = Subject;
        //    mailmessage.Body = body;
        //    mailmessage.ReplyTo = new MailAddress(from);
        //    mailmessage.IsBodyHtml = true;
        //    SmtpClient client = new SmtpClient();
        //    client.Port = 587;
        //    client.EnableSsl = true;

        //    client.UseDefaultCredentials = true;
        //    client.Host = "smtp.gmail.com";

        //    client.Credentials = new NetworkCredential("Jaswantrajpoot060@gmail.com", "@jassi3583");

        //    //Add this line to bypass the certificate validation
        //    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
        //    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
        //    System.Security.Cryptography.X509Certificates.X509Chain chain,
        //    System.Net.Security.SslPolicyErrors sslPolicyErrors)
        //    {
        //        return true;
        //    };
        //    client.Send(mailmessage);

        //}
        public static void SendMail(string mailto, string Subject, string body)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress("info@eimtindia.com")
            };
            message.To.Add(new MailAddress(mailto));
            message.To.Add("eimtfranchi@gmail.com");
            message.Subject = Subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = "relay-hosting.secureserver.net", // mail.emaitindia.com .webamial
                Port = 25,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("info@eimtindia.com", "Edubright@1234")
            };
            client.Send(message);
        }

        public static void SendNew(string mailto, string from, string Subject, string body)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress("info@eimtindia.com")
            };
            message.To.Add(new MailAddress(mailto));
            message.To.Add("eimtfranchi@gmail.com");
            message.Subject = Subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = "relay-hosting.secureserver.net", // mail.emaitindia.com .webamial
                Port = 25,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("info@eimtindia.com", "Edubright@1234")
            };
            client.Send(message);
        }
    }
}
