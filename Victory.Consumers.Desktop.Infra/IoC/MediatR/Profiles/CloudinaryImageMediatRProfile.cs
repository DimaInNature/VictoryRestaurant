namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class CloudinaryImageMediatRProfile
{
    public static void AddCloudinaryImageMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        // Create

        services.AddScoped<IRequest<string?>, UploadImageCommand>();
        services.AddScoped<IRequestHandler<UploadImageCommand, string?>, UploadImageCommandHandler>();

        #endregion
    }
}