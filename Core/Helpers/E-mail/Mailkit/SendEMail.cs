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
            var launchSettingsConfig = configuration.GetSection("profiles")
                .GetChildren()
                .FirstOrDefault(c => c["commandName"] == "Project" && c["env"] == "Development")
                ?.GetSection("environmentVariables");

            if (launchSettingsConfig != null)
            {
                fromName = launchSettingsConfig["MailKit:fromName"];
                toName = launchSettingsConfig["MailKit:toName"];
                host = launchSettingsConfig["MailKit:host"];
                port = Convert.ToInt32(launchSettingsConfig["MailKit:port"]);
                fromAddress = launchSettingsConfig["MailKit:fromAddress"];
                password = launchSettingsConfig["MailKit:password"];
            }
            else
            {
                throw new InvalidOperationException("Could not find launchSettings configuration for MailKit.");
            }
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
