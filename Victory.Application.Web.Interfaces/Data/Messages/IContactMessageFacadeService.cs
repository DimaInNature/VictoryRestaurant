namespace Victory.Application.Web.Interfaces.Data.Messages;

public interface IContactMessageFacadeService
{
    Task CreateAsync(ContactMessage entity);
}