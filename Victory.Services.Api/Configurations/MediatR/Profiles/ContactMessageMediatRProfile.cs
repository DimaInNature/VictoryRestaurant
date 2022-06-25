namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
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

        // Update by Id

        services.AddScoped<IRequest, UpdateContactMessageCommand>();
        services.AddScoped<IRequestHandler<UpdateContactMessageCommand, Unit>, UpdateContactMessageCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteContactMessageCommand>();
        services.AddScoped<IRequestHandler<DeleteContactMessageCommand, Unit>, DeleteContactMessageCommandHandler>();

        #endregion
    }
}