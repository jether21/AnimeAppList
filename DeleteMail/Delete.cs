using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;

namespace new_email_tool
{
    internal class Delete
    {
        static void Main(string[] args)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Customer List System", "jetherazeltanon@gmail.com"));
            message.To.Add(new MailboxAddress("Jether Tanon", "jetherazeltanon@gmail.com"));
            message.Subject = "Customer List System";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Hi, User!</h1>" +
                "<p>Successfully Deleted to the list.</p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("700ab50ea5a2ad", "b2f021a1b0042c");

                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
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