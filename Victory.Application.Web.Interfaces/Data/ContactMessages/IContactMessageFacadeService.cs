namespace Victory.Application.Web.Interfaces.Data.ContactMessages;

public interface IContactMessageFacadeService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int id);
    Task DeleteAsync(int id);
}