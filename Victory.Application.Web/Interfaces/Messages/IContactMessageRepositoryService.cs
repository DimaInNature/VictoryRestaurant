namespace Victory.Application.Web.Interfaces;

public interface IContactMessageRepositoryService
{
    Task CreateAsync(ContactMessage entity);
}