using CoreLayer.Utilities.Results;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.E_mail.Mailkit
{
    public class SendEMailByGmail : IEmailSender
    {
        private readonly string fromName;
        private readonly string toName;
        private readonly string host;
        private readonly int port;
        private readonly string fromAddress;
        private readonly string password;

        public SendEMailByGmail(IConfiguration configuration)
        {
            //fromName = Environment.GetEnvironmentVariable("fromName");
            fromName = configuration["fromName"];
            toName = configuration["toName"];
            host = configuration["host"];
            port = Convert.ToInt32(configuration["port"]);
            fromAddress = configuration["fromAddress"];
            password = configuration["password"];
        }
        public async Task<IResult> SendText(string toAddress, string subject, string textBody)
        {
            return await SendEmail(toAddress, subject, textBody, false);
        }

        public async Task<IResult> SendHtml(string toAddress, string subject, string htmlBody)
        {
            return await SendEmail(toAddress, subject, htmlBody, true);
        }

        private async Task<IResult> SendEmail(string toAddress, string subject, string body, bool isHtml)
        {
            try
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress from = new MailboxAddress(fromName, fromAddress);
                MailboxAddress to = new MailboxAddress(toName, toAddress);
                mimeMessage.From.Add(from);
                mimeMessage.To.Add(to);
                mimeMessage.Subject = subject ?? string.Empty;

                BodyBuilder bodyBuilder = new BodyBuilder();
                if (isHtml)
                    bodyBuilder.HtmlBody = body;
                else
                    bodyBuilder.TextBody = body;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect(host, port, false);
                smtpClient.Authenticate(fromAddress, password);
                await smtpClient.SendAsync(mimeMessage);
                await smtpClient.DisconnectAsync(true);

                return new SuccessResult("Email sent successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
