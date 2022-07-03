namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class BookingMediatRProfile
{
    public static void AddBookingMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get BookingEntity by Id

        services.AddScoped<IRequest<BookingEntity?>, GetBookingByIdQuery>();
        services.AddScoped<IRequestHandler<GetBookingByIdQuery, BookingEntity?>, GetBookingByIdQueryHandler>();

        // Get BookingEntity.Table by Id

        services.AddScoped<IRequest<TableEntity?>, GetBookingTableByIdQuery>();
        services.AddScoped<IRequestHandler<GetBookingTableByIdQuery, TableEntity?>, GetBookingTableByIdQueryHandler>();

        // Get List<BookingEntity>

        services.AddScoped<IRequest<List<BookingEntity>?>, GetBookingListQuery>();
        services.AddScoped<IRequestHandler<GetBookingListQuery, List<BookingEntity>?>, GetBookingListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateBookingCommand>();
        services.AddScoped<IRequestHandler<CreateBookingCommand, Unit>, CreateBookingCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateBookingCommand>();
        services.AddScoped<IRequestHandler<UpdateBookingCommand, Unit>, UpdateBookingCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteBookingCommand>();
        services.AddScoped<IRequestHandler<DeleteBookingCommand, Unit>, DeleteBookingCommandHandler>();

        #endregion
    }
}