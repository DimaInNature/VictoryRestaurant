﻿namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

public static class FoodMediatRProfile
{
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get List<Food>

        services.AddScoped<IRequest<List<Food>?>, GetFoodListQuery>();
        services.AddScoped<IRequestHandler<GetFoodListQuery, List<Food>?>, GetFoodListQueryHandler>();

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