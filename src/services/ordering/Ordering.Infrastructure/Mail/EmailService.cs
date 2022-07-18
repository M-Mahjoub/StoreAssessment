using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Models;
using Store.Application.Contracts.Infrastructure;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; set; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            //Send Email

            return false;
        }
    }
}
