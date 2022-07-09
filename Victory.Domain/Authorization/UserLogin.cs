namespace Victory.Domain.Authorization;

public class UserLogin
{
    public string? Login { get; set; }

    public string? Password { get; set; }

    public UserLogin(string login, string password) => (Login, Password) = (login, password);

    public UserLogin() { }
}