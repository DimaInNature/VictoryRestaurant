namespace VictoryRestaurant.API.Authorization;

public class AuthorizationApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/Login", [AllowAnonymous] async (HttpContext context,
            ITokenService tokenService, IUserRepository repository) =>
        {
            UserEntity user = new()
            {
                Login = context.Request.Query["login"],
                Password = context.Request.Query["password"]
            };

            var userFromDb = await repository.GetUserAsync(user);

            if (userFromDb is null) return Results.Unauthorized();

            var token = tokenService.GetToken(app.Configuration["Jwt:Key"],
                app.Configuration["Jwt:Issuer"], userFromDb);

            return Results.Ok(token);
        });
    }
}