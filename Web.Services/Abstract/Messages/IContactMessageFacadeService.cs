namespace Web.Services.Abstract.Messages;

public interface IContactMessageFacadeService
{
    Task InsertContactMessageAsync(ContactMessage contactMessage);
}
