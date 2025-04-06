namespace ecommerce.Models.Custom
{
    public class MailRequest
    {
        //mail gönderme işlemi için oluşturulmuştur
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
