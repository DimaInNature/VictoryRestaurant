namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class FoodTypeMediatRProfile
{
    public static void AddFoodTypeMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

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