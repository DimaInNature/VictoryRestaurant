namespace Web.Services.Abstract.Messages;

public interface IContactMessageRepositoryService
{
    Task InsertContactMessageAsync(ContactMessage contactMessage);
}
