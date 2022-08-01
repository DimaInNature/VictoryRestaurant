namespace Victory.Microservices.FoodService.Infra.IoC.MediatR.Profiles;

public static class FoodTypeTypeMediatRProfile
{
    public static void AddFoodTypeMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddTransient<IRequest<Unit>, CreateFoodTypeCommand>();
        services.AddTransient<IRequestHandler<CreateFoodTypeCommand, Unit>, CreateFoodTypeCommandHandler>();

        services.AddTransient<IRequest<Unit>, UpdateFoodTypeCommand>();
        services.AddTransient<IRequestHandler<UpdateFoodTypeCommand, Unit>, UpdateFoodTypeCommandHandler>();

        services.AddTransient<IRequest<Unit>, DeleteFoodTypeCommand>();
        services.AddTransient<IRequestHandler<DeleteFoodTypeCommand, Unit>, DeleteFoodTypeCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<FoodTypeEntity?>, GetFoodTypeByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeByPredicateQuery, FoodTypeEntity?>, GetFoodTypeByPredicateQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<FoodTypeEntity>>, GetFoodTypeListQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListQuery, IEnumerable<FoodTypeEntity>>, GetFoodTypeListQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<FoodTypeEntity>>, GetFoodTypeListByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListByPredicateQuery, IEnumerable<FoodTypeEntity>>, GetFoodTypeListByPredicateQueryHandler>();

        #endregion
    }
}