using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Email
{
    class SentEmail
    {
        SmtpClient client;
        MailMessage mm;
        String user;
        String password;
        String server;
        int port;

        public SentEmail()
        {
            user = "aquí user";
            password = "aquí pass";
            server = "smtp.gmail.com";
            port = 587;
            client = new SmtpClient();
            client.Port = port;
            client.Host = server;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(user, password);
        }
        public Boolean sentMessage(String recipient, String subject, String content)
        {
            String allMessage = "";

            allMessage = "<html>" + "<IMG src='https://www.adslzone.net/app/uploads-adslzone.net/2021/01/ofertas.jpg' width='200' height='200'> </br> <p>" + content + "</p><br/><br/>" + "</html>";
            mm = new MailMessage(user, recipient, subject, allMessage);
            mm.IsBodyHtml = true;
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
            return true;
        }
    }
}
