using System.Net.Mail;
using System.Net;

namespace TechnoAcademyApi.Utils
{
    public class EmailSender
    {
        private string _senderEmail;
        private string _senderPassword;
        private string _smtpHost;
        private int _smtpPort;
        private string _senderName;
        public EmailSender(string senderEmail, string senderPassword, string smtpHost, int smtpPort, string senderName)
        {
            _senderEmail = senderEmail;
            _senderPassword = senderPassword;
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _senderName = senderName;
        }
        public void SendRegistrationEmail(string receiverEmail)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_senderEmail, _senderName);
            mail.To.Add(receiverEmail);
            mail.Subject = "Registrasi Berhasil";
            mail.Body = "Selamat, Anda telah berhasil melakukan registrasi.";

            SmtpClient smtpClient = new SmtpClient(_smtpHost, _smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
