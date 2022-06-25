namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class FoodMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get Food by Id

        services.AddScoped<IRequest<Food?>, GetFoodByIdQuery>();
        services.AddScoped<IRequestHandler<GetFoodByIdQuery, Food?>, GetFoodByIdQueryHandler>();

        // Get Food by Type

        services.AddScoped<IRequest<Food?>, GetFoodByTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodByTypeQuery, Food?>, GetFoodByTypeQueryHandler>();

        // Get List<Food>

        services.AddScoped<IRequest<List<Food>?>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, List<Food>?>, GetFoodListQueryHandler>();

        // Get List<Food> by Type

        services.AddScoped<IRequest<List<Food>?>, GetFoodListByTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByTypeQuery, List<Food>?>, GetFoodListByTypeQueryHandler>();

        // Get List<Food> by Name

        services.AddScoped<IRequest<List<Food>?>, GetFoodListByNameQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByNameQuery, List<Food>?>, GetFoodListByNameQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateFoodCommand>();
        services.AddScoped<IRequestHandler<CreateFoodCommand, Unit>, CreateFoodCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateFoodCommand>();
        services.AddScoped<IRequestHandler<UpdateFoodCommand, Unit>, UpdateFoodCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteFoodCommand>();
        services.AddScoped<IRequestHandler<DeleteFoodCommand, Unit>, DeleteFoodCommandHandler>();

        #endregion
    }
}