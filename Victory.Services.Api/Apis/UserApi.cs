namespace Victory.Services.Api;

public class UserApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet(pattern: "/Users", handler: GetAll)
            .Produces<List<UserEntity>>(StatusCodes.Status200OK)
            .WithName("GetAllUsers")
            .WithTags("Getters");

        app.MapGet(pattern: "/Users/Id/{id}", handler: GetById)
           .Produces<UserEntity>(StatusCodes.Status200OK)
           .WithName("GetUser")
           .WithTags("Getters");

        app.MapGet(pattern: "/Users/Login/{login}", handler: GetByLogin)
           .Produces<UserEntity>(StatusCodes.Status200OK)
           .WithName("GetUserByLogin")
           .WithTags("Getters");

        app.MapGet(pattern: "/Users/Login/{login}/Password/{password}", handler: GetByLoginAndPassword)
          .Produces<UserEntity>(StatusCodes.Status200OK)
          .WithName("GetUserByLoginAndPassword")
          .WithTags("Getters");

        app.MapPost(pattern: "/Users", handler: Create)
            .Accepts<UserEntity>("application/json")
            .Produces<UserEntity>(StatusCodes.Status201Created)
            .WithName("CreateUser")
            .WithTags("Creators");

        app.MapPut(pattern: "/Users", handler: Put)
            .Accepts<UserEntity>("application/json")
            .WithName("UpdateUser")
            .WithTags("Updaters");

        app.MapDelete(pattern: "/Users/{id}", handler: Delete)
            .WithName("DeleteUser")
            .WithTags("Deleters");
    }

    private async Task<IResult> GetAll(IUserFacadeService repository)
        => Results.Ok(await repository.GetUserListAsync());

    private async Task<IResult> GetById(int id, IUserFacadeService repository)
        => await repository.GetUserAsync(id) is UserEntity user
        ? Results.Ok(user)
        : Results.NotFound();

    private async Task<IResult> GetByLogin(string login, IUserFacadeService repository)
        => await repository.GetUserAsync(login) is UserEntity user
        ? Results.Ok(user)
        : Results.NotFound();

    private async Task<IResult> GetByLoginAndPassword(string login,
        string password, IUserFacadeService repository) =>
        await repository.GetUserAsync(login, password) is UserEntity user
        ? Results.Ok(user)
        : Results.NotFound();

    private async Task<IResult> Create([FromBody] UserEntity user,
        IUserFacadeService repository)
    {
        await repository.CreateAsync(user);

        return Results.Created($"/Users/{user.Id}", user);
    }

    private async Task<IResult> Put([FromBody] UserEntity user,
        IUserFacadeService repository)
    {
        await repository.UpdateAsync(user);

        return Results.NoContent();
    }

    private async Task<IResult> Delete(int id,
        IUserFacadeService repository)
    {
        await repository.DeleteAsync(id);

        return Results.NoContent();
    }
}