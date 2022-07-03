namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class FoodTypeMediatRProfile
{
    public static void AddFoodTypeMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get FoodTypeEntity by Id

        services.AddScoped<IRequest<FoodTypeEntity?>, GetFoodTypeByIdQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeByIdQuery, FoodTypeEntity?>, GetFoodTypeByIdQueryHandler>();

        // Get List<FoodTypeEntity>

        services.AddScoped<IRequest<List<FoodTypeEntity>?>, GetFoodTypeListQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListQuery, List<FoodTypeEntity>?>, GetFoodTypeListQueryHandler>();

        // Get List<FoodTypeEntity> by Name

        services.AddScoped<IRequest<List<FoodTypeEntity>?>, GetFoodTypeListByNameQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListByNameQuery, List<FoodTypeEntity>?>, GetFoodTypeListByNameQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateFoodTypeCommand>();
        services.AddScoped<IRequestHandler<CreateFoodTypeCommand, Unit>, CreateFoodTypeCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateFoodTypeCommand>();
        services.AddScoped<IRequestHandler<UpdateFoodTypeCommand, Unit>, UpdateFoodTypeCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteFoodTypeCommand>();
        services.AddScoped<IRequestHandler<DeleteFoodTypeCommand, Unit>, DeleteFoodTypeCommandHandler>();

        #endregion
    }
}