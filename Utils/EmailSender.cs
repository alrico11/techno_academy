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
        public EmailSender(string senderEmail, string senderPassword, string smtpHost, int smtpPort)
        {
            _senderEmail = senderEmail;
            _senderPassword = senderPassword;
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
        }
        public void SendRegistrationEmail(string receiverEmail)
        {
            // Membuat objek MailMessage
            MailMessage mail = new MailMessage(_senderEmail, receiverEmail);
            mail.Subject = "Registrasi Berhasil";
            mail.Body = "Selamat, Anda telah berhasil melakukan registrasi.";

            // Konfigurasi client SMTP
            SmtpClient smtpClient = new SmtpClient(_smtpHost, _smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);

            try
            {
                // Mengirim email
                smtpClient.Send(mail);
                Console.WriteLine("Email sukses registrasi berhasil dikirim.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal mengirim email sukses registrasi: " + ex.Message);
            }
        }
    }
}
