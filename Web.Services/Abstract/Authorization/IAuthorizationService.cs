namespace Web.Services.Abstract.Authorization;

public interface IAuthorizationService
{
    Task<HttpResponseMessage> GetToken(User user);
}