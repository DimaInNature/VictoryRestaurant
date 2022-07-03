namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

internal static class CloudinaryImageMediatRProfile
{
    public static void AddCloudinaryImageMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        // Create

        services.AddScoped<IRequest<string?>, UploadImageCommand>();
        services.AddScoped<IRequestHandler<UploadImageCommand, string?>, UploadImageCommandHandler>();

        #endregion
    }
}