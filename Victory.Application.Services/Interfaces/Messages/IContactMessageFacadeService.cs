namespace Victory.Application.Services.Interfaces;

public interface IContactMessageFacadeService
{
    Task<List<ContactMessageEntity>> GetContactMessageListAsync();
    Task<ContactMessageEntity?> GetContactMessageAsync(int id);
    Task CreateAsync(ContactMessageEntity entity);
    Task UpdateAsync(ContactMessageEntity entity);
    Task DeleteAsync(int id);
}