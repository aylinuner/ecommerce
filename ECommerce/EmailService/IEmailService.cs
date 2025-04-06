using ecommerce.Models.Custom;

namespace Project.ecommerce.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest email);
    }
}
