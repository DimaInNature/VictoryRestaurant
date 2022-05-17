namespace Victory.Application.Web.Interfaces.Data.Messages;

public interface IContactMessageRepositoryService
{
    Task CreateAsync(ContactMessage entity);
}