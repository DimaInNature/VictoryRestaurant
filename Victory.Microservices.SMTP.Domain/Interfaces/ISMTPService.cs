namespace Victory.Microservices.SMTP.Domain.Interfaces;

public interface ISMTPService
{
    public Task SendAllAsync(EmailMessage message);
}