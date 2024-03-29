﻿namespace Victory.Presentation.Mobile.Core.Configuration.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

        services.AddFoodMediatRProfile();

        services.AddBookingMediatRProfile();
    }
}