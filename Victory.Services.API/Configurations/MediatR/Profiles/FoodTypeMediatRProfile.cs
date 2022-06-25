namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class FoodTypeMediatRProfile
{
    public static void AddFoodTypeMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get FoodType by Id

        services.AddScoped<IRequest<FoodType?>, GetFoodTypeByIdQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeByIdQuery, FoodType?>, GetFoodTypeByIdQueryHandler>();

        // Get List<FoodType>

        services.AddScoped<IRequest<List<FoodType>?>, GetFoodTypeListQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListQuery, List<FoodType>?>, GetFoodTypeListQueryHandler>();

        // Get List<FoodType> by Name

        services.AddScoped<IRequest<List<FoodType>?>, GetFoodTypeListByNameQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListByNameQuery, List<FoodType>?>, GetFoodTypeListByNameQueryHandler>();

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