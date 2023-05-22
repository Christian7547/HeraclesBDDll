using System;
using System.Net;
using System.Net.Mail;

namespace HeraclesDAO.SMTP
{
    public class EmailManager
    {
        public bool SendEmail(string fromEmail, string toEmail, string content)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, "bvbjxwhgykrnkdxr");
                    smtpClient.Send(fromEmail, toEmail, "HERACLES", content);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
