namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get ContactMessageEntity by Id

        services.AddScoped<IRequest<ContactMessageEntity?>, GetContactMessageByIdQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageByIdQuery, ContactMessageEntity?>, GetContactMessageByIdQueryHandler>();

        // Get List<ContactMessageEntity>

        services.AddScoped<IRequest<List<ContactMessageEntity>?>, GetContactMessageListQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageListQuery, List<ContactMessageEntity>?>, GetContactMessageListQueryHandler>();

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