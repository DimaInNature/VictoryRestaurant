namespace VictoryRestaurant.API.Apis;

public class UserApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet(pattern: "/Users", handler: GetAll)
            .Produces<List<UserEntity>>(StatusCodes.Status200OK)
            .WithName("GetAllUsers")
            .WithTags("Getters");

        //app.MapGet(pattern: "/Users/{id}", handler: GetById)
        //   .Produces<UserEntity>(StatusCodes.Status200OK)
        //   .WithName("GetUser")
        //   .WithTags("Getters");

        app.MapGet(pattern: "/Users/{login}", handler: GetByLogin)
           .Produces<UserEntity>(StatusCodes.Status200OK)
           .WithName("GetUserByLogin")
           .WithTags("Getters");

        app.MapGet(pattern: "/Users/{login}And{password}", handler: GetByLoginAndPassword)
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

    [AllowAnonymous]
    private async Task<IResult> GetAll(IUserFacadeService repository)
        => Results.Ok(await repository.GetUsersAsync());

    [Authorize]
    private async Task<IResult> GetById(int id, IUserFacadeService repository)
        => await repository.GetUserAsync(userId: id) is UserEntity user
        ? Results.Ok(user)
        : Results.NotFound();

    [AllowAnonymous]
    private async Task<IResult> GetByLogin(string login, IUserFacadeService repository)
        => await repository.GetUserAsync(login: login) is UserEntity user
        ? Results.Ok(user)
        : Results.NotFound();

    [AllowAnonymous]
    private async Task<IResult> GetByLoginAndPassword(string login,
        string password, IUserFacadeService repository) =>
        await repository.GetUserAsync(login: login, password: password) is UserEntity user
        ? Results.Ok(user)
        : Results.NotFound();

    [AllowAnonymous]
    private async Task<IResult> Create([FromBody] UserEntity user,
        IUserFacadeService repository)
    {
        await repository.InsertUserAsync(user);

        await repository.SaveAsync();

        return Results.Created($"/Users/{user.Id}", user);
    }

    [Authorize]
    private async Task<IResult> Put([FromBody] UserEntity user,
        IUserFacadeService repository)
    {
        await repository.UpdateUserAsync(user);

        await repository.SaveAsync();

        return Results.NoContent();
    }

    [Authorize]
    private async Task<IResult> Delete(int id,
        IUserFacadeService repository)
    {
        await repository.DeleteUserAsync(id);

        await repository.SaveAsync();

        return Results.NoContent();
    }
}