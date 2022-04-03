namespace Victory.Application.Web.Interfaces;

public interface IContactMessageFacadeService
{
    Task CreateAsync(ContactMessage entity);
}