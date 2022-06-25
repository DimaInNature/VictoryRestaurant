namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class BookingMediatRProfile
{
    public static void AddBookingMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get Booking by Id

        services.AddScoped<IRequest<Booking?>, GetBookingByIdQuery>();
        services.AddScoped<IRequestHandler<GetBookingByIdQuery, Booking?>, GetBookingByIdQueryHandler>();

        // Get Booking.Table by Id

        services.AddScoped<IRequest<Table?>, GetBookingTableByIdQuery>();
        services.AddScoped<IRequestHandler<GetBookingTableByIdQuery, Table?>, GetBookingTableByIdQueryHandler>();

        // Get List<Booking>

        services.AddScoped<IRequest<List<Booking>?>, GetBookingListQuery>();
        services.AddScoped<IRequestHandler<GetBookingListQuery, List<Booking>?>, GetBookingListQueryHandler>();

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