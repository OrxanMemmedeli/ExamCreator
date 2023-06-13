using CoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.E_mail.Mailkit
{
    public interface IEmailSender
    {
        Task<IResult> SendText(string toAddress, string subject, string textBody);
        Task<IResult> SendHtml(string toAddress, string subject, string htmlBody);
    }
}
