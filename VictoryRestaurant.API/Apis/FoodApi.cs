namespace VictoryRestaurant.API.Apis;

public class FoodApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet(pattern: "/Foods", handler: GetAll)
            .Produces<List<FoodEntity>>(StatusCodes.Status200OK)
            .WithName("GetAllFoods")
            .WithTags("Getters");

        app.MapGet(pattern: "/Foods/{id}", handler: GetById)
            .Produces<FoodEntity>(StatusCodes.Status200OK)
            .WithName("GetFood")
            .WithTags("Getters");

        app.MapGet(pattern: "/Foods/Type/{type}", handler: GetFirstByFoodType)
            .Produces<FoodEntity>(StatusCodes.Status200OK)
            .WithName("GetFoodByFoodType")
            .WithTags("Getters");

        app.MapGet(pattern: "/Foods/Search/Name/{query}", handler: GetAllByName)
            .Produces<List<FoodEntity>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchFoodsByName")
            .WithTags("Getters");

        app.MapGet(pattern: "/Foods/Search/Type/{type}", handler: GetAllByFoodType)
            .Produces<List<FoodEntity>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchFoodsByType")
            .WithTags("Getters");

        app.MapPost(pattern: "/Foods", handler: Create)
            .Accepts<FoodEntity>("application/json")
            .Produces<FoodEntity>(StatusCodes.Status201Created)
            .WithName("CreateFood")
            .WithTags("Creators");

        app.MapPut(pattern: "/Foods", handler: Put)
            .Accepts<FoodEntity>("application/json")
            .WithName("UpdateFood")
            .WithTags("Updaters");

        app.MapDelete(pattern: "/Foods/{id}", handler: Delete)
            .WithName("DeleteFood")
            .WithTags("Deleters");
    }

    [AllowAnonymous]
    private async Task<IResult> GetAll(IFoodFacadeService repository)
        => Results.Ok(await repository.GetFoodsAsync());

    [AllowAnonymous]
    private async Task<IResult> GetById(int id, IFoodFacadeService repository) =>
        await repository.GetFoodAsync(foodId: id) is FoodEntity food
        ? Results.Ok(food)
        : Results.NotFound();

    [AllowAnonymous]
    private async Task<IResult> GetFirstByFoodType(FoodType type, IFoodFacadeService repository) =>
        await repository.GetFoodByFootTypeAsync(type: type) is FoodEntity food
        ? Results.Ok(food)
        : Results.NotFound();

    [AllowAnonymous]
    private async Task<IResult> GetAllByName(string query, IFoodFacadeService repository)
        => await repository.GetFoodsAsync(query) is IEnumerable<FoodEntity> foods
        ? Results.Ok(foods)
        : Results.NotFound(Array.Empty<FoodEntity>());

    [AllowAnonymous]
    private async Task<IResult> GetAllByFoodType(FoodType type, IFoodFacadeService repository)
        => await repository.GetFoodsAsync(type) is IEnumerable<FoodEntity> foods
        ? Results.Ok(foods)
        : Results.NotFound(Array.Empty<FoodEntity>());

    [AllowAnonymous]
    private async Task<IResult> Create([FromBody] FoodEntity food,
        IFoodFacadeService repository)
    {
        await repository.InsertFoodAsync(food);

        await repository.SaveAsync();

        return Results.Created($"/Foods/{food.Id}", food);
    }

    [AllowAnonymous]
    private async Task<IResult> Put([FromBody] FoodEntity food,
        IFoodFacadeService repository)
    {
        await repository.UpdateFoodAsync(food);

        await repository.SaveAsync();

        return Results.NoContent();
    }

    [AllowAnonymous]
    private async Task<IResult> Delete(int id,
        IFoodFacadeService repository)
    {
        await repository.DeleteFoodAsync(id);

        await repository.SaveAsync();

        return Results.NoContent();
    }
}