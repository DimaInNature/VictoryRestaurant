namespace Web.Data.Repositories.Abstract;

public interface IContactMessageRepository
{
    Task InsertContactMessageAsync(ContactMessageEntity contactMessage);
}
