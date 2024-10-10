using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace AnimeBusinessService
{
    public class AniService
    {
         string _smtpServer = "sandbox.smtp.mailtrap.io";
          int _port = 2525;
         string _userName = "700ab50ea5a2ad";
         string _password = "b2f021a1b0042c";
         string _recipientName = "Jether Tanon";
         string _recipientEmail = "jetherazeltanon@gmail.com";

        public void SendEmail(string subject, string htmlBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Customer List System", "jetherazeltanon@gmail.com"));
            message.To.Add(new MailboxAddress(_recipientName, _recipientEmail));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlBody
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpServer, _port, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(_userName, _password);
                    client.Send(message);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (MailKit.Net.Smtp.SmtpCommandException ex)
                {
                    // Specific MailKit command-related errors
                    Console.WriteLine($"SMTP Command Error: {ex.Message} (StatusCode: {ex.StatusCode})");
                }
                catch (MailKit.Net.Smtp.SmtpProtocolException ex)
                {
                    // General protocol-related errors
                    Console.WriteLine($"SMTP Protocol Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Any other errors
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
