namespace Victory.Consumers.Web.Domain.Interfaces.ContactMessages;

public interface IContactMessageService
{
    Task CreateAsync(ContactMessage entity);
}