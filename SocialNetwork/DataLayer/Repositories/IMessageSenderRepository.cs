namespace SocialNetwork.DataLayer.Repositories
{
    public interface IMessageSenderRepository
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}
