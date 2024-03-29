﻿namespace Victory.Consumers.Web.Infra.IoC.MediatR.Profiles;

public static class FoodMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        // Get List<Food>

        services.AddScoped<IRequest<List<Food>?>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, List<Food>?>, GetFoodListQueryHandler>();

        // Get List<Food> by FoodType

        services.AddScoped<IRequest<List<Food>?>, GetFoodListByFoodTypeQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByFoodTypeQuery, List<Food>?>, GetFoodListByFoodTypeQueryHandler>();

        #endregion
    }
}