namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        // Get ContactMessage by Id

        services.AddScoped<IRequest<ContactMessage?>, GetContactMessageByIdQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>, GetContactMessageByIdQueryHandler>();

        // Get List<ContactMessage>

        services.AddScoped<IRequest<List<ContactMessage>?>, GetContactMessageListQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageListQuery, List<ContactMessage>?>, GetContactMessageListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateContactMessageCommand>();
        services.AddScoped<IRequestHandler<CreateContactMessageCommand, Unit>, CreateContactMessageCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteContactMessageCommand>();
        services.AddScoped<IRequestHandler<DeleteContactMessageCommand, Unit>, DeleteContactMessageCommandHandler>();

        #endregion
    }
}