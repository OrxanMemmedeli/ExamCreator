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
    public class SendEMail
    {
        private readonly string fromName;
        private readonly string toName;
        private readonly string host;
        private readonly int port;
        private readonly string fromAddress;
        private readonly string password;

        public SendEMail(IConfiguration configuration)
        {
            //fromName = Environment.GetEnvironmentVariable("fromName");
            fromName = configuration["fromName"];
            toName = configuration["toName"];
            host = configuration["host"];
            port = Convert.ToInt32(configuration["port"]);
            fromAddress = configuration["fromAddress"];
            password = configuration["password"];
        }
        public async Task<IResult> Send(string toAdress, string textBody)
        {
            try
            {
                MimeMessage mimeMessage = new();

                MailboxAddress From = new MailboxAddress(fromName, fromAddress);
                MailboxAddress To = new MailboxAddress(toName, toAdress);
                mimeMessage.From.Add(From);
                mimeMessage.To.Add(To);

                BodyBuilder bodyBuilder = new();
                bodyBuilder.TextBody = textBody;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                SmtpClient smtpClient = new();
                smtpClient.Connect(host, port, false);
                smtpClient.Authenticate(fromAddress, password);
                await smtpClient.SendAsync(mimeMessage);
                await smtpClient.DisconnectAsync(true);

                return new SuccessResult("E-mail sent successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);

            }
        }
    }
}
