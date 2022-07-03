namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class FoodEntityMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get FoodEntity by Id

        services.AddScoped<IRequest<FoodEntity?>, GetFoodByIdQuery>();
        services.AddScoped<IRequestHandler<GetFoodByIdQuery, FoodEntity?>, GetFoodByIdQueryHandler>();

        // Get FoodEntity by Type

        services.AddScoped<IRequest<FoodEntity?>, GetFoodByTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodByTypeQuery, FoodEntity?>, GetFoodByTypeQueryHandler>();

        // Get List<FoodEntity>

        services.AddScoped<IRequest<List<FoodEntity>?>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, List<FoodEntity>?>, GetFoodListQueryHandler>();

        // Get List<FoodEntity> by Type

        services.AddScoped<IRequest<List<FoodEntity>?>, GetFoodListByTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByTypeQuery, List<FoodEntity>?>, GetFoodListByTypeQueryHandler>();

        // Get List<FoodEntity> by Name

        services.AddScoped<IRequest<List<FoodEntity>?>, GetFoodListByNameQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByNameQuery, List<FoodEntity>?>, GetFoodListByNameQueryHandler>();

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