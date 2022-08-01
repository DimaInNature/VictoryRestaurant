namespace Victory.Microservices.FoodService.Infra.IoC.MediatR.Profiles;

public static class FoodMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddTransient<IRequest<Unit>, CreateFoodCommand>();
        services.AddTransient<IRequestHandler<CreateFoodCommand, Unit>, CreateFoodCommandHandler>();

        services.AddTransient<IRequest<Unit>, UpdateFoodCommand>();
        services.AddTransient<IRequestHandler<UpdateFoodCommand, Unit>, UpdateFoodCommandHandler>();

        services.AddTransient<IRequest<Unit>, DeleteFoodCommand>();
        services.AddTransient<IRequestHandler<DeleteFoodCommand, Unit>, DeleteFoodCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<FoodEntity?>, GetFoodByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetFoodByPredicateQuery, FoodEntity?>, GetFoodByPredicateQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<FoodEntity>>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, IEnumerable<FoodEntity>>, GetFoodListQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<FoodEntity>>, GetFoodListByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByPredicateQuery, IEnumerable<FoodEntity>>, GetFoodListByPredicateQueryHandler>();

        #endregion
    }
}