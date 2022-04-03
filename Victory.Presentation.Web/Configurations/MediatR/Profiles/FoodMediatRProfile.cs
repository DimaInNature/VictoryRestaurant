namespace Victory.Presentation.Web.Configurations.MediatR.Profiles;

public static class FoodMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Food>

        services.AddScoped<IRequest<List<Food>?>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, List<Food>?>, GetFoodListQueryHandler>();

        // Get List<Food> by FoodType

        services.AddScoped<IRequest<List<Food>?>, GetFoodListByFoodTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByFoodTypeQuery, List<Food>?>, GetFoodListByFoodTypeQueryHandler>();

        // Get Food by FoodType

        services.AddScoped<IRequest<Food?>, GetFoodByFoodTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodByFoodTypeQuery, Food?>, GetFoodByFoodTypeQueryHandler>();

        #endregion
    }
}