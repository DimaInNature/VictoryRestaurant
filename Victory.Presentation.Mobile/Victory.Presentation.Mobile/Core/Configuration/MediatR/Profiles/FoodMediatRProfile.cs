namespace Victory.Presentation.Mobile.Core.Configuration.MediatR.Profiles;

public static class FoodMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Food>

        services.AddScoped<IRequest<List<Food>?>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, List<Food>?>, GetFoodListQueryHandler>();

        #endregion
    }
}