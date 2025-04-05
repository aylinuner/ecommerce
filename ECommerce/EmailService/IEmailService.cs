using ecommerce.Models;

namespace Project.ecommerce.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest email);
    }
}
