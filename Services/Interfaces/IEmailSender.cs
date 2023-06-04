namespace MeuRastroCarbonoAPI.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendRenewPasswordEmailAsync(string fromEmail, string toEmail, string smtpDomain, int smtpPort, string name, string code, string fromEmailPassword);
    }
}
