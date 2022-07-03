namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

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

        #endregion

    }
}