namespace API.Services.Abstract.Authorization;

public interface ITokenService
{
    string GetToken(string key, string issuer, UserEntity user);
}