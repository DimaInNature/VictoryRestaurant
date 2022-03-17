namespace VictoryRestaurant.API.Authorization;

public class AuthorizationApi : IApi
{
    public void Register(WebApplication app)
    {
        //// Get token
        app.MapPost("/Token", [AllowAnonymous] async (HttpContext context,
            ITokenService tokenService, IUserRepository repository) =>
        {
            UserEntity user = new()
            {
                Login = context.Request.Query["login"],
                Password = context.Request.Query["password"]
            };

            var identity = await GetIdentity(user.Login, user.Password, repository);
            if (identity == null)
            {
                return Results.BadRequest(new { errorText = "Invalid username or password." });
            }

            var userFromDb = await repository.GetUserAsync(user.Login, user.Password);

            if (userFromDb is null) return Results.Unauthorized();

            var token = tokenService.GetToken(app.Configuration["Jwt:Key"],
                app.Configuration["Jwt:Issuer"], userFromDb);

            var response = new
            {
                access_token = token,
                login = identity.Name
            };

            return Results.Ok(response);
        });
    }

    private async Task<ClaimsIdentity> GetIdentity(string login, string password, IUserRepository _userService)
    {
        UserEntity user = await _userService.GetUserAsync(login: login, password: password);
        if (user is not null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        // если пользователя не найдено
        return null;
    }
}