namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class BookingMediatRProfile
{
    public static void AddBookingMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        // Get Booking by Id

        services.AddScoped<IRequest<Booking?>, GetBookingByIdQuery>();
        services.AddScoped<IRequestHandler<GetBookingByIdQuery, Booking?>, GetBookingByIdQueryHandler>();

        // Get List<Booking>

        services.AddScoped<IRequest<List<Booking>?>, GetBookingListQuery>();
        services.AddScoped<IRequestHandler<GetBookingListQuery, List<Booking>?>, GetBookingListQueryHandler>();

        // Get Booking.Table by Id

        services.AddScoped<IRequest<Table?>, GetBookingTableByIdQuery>();
        services.AddScoped<IRequestHandler<GetBookingTableByIdQuery, Table?>, GetBookingTableByIdQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest<Booking?>, CreateBookingCommand>();
        services.AddScoped<IRequestHandler<CreateBookingCommand, Booking?>, CreateBookingCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteBookingCommand>();
        services.AddScoped<IRequestHandler<DeleteBookingCommand, Unit>, DeleteBookingCommandHandler>();

        #endregion
    }
}