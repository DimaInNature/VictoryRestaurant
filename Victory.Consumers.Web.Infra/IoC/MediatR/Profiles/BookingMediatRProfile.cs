namespace Victory.Consumers.Web.Infra.IoC.MediatR.Profiles;

public static class BookingMediatRProfile
{
    public static void AddBookingMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        // Create

        services.AddScoped<IRequest<Booking?>, CreateBookingCommand>();
        services.AddScoped<IRequestHandler<CreateBookingCommand, Booking?>, CreateBookingCommandHandler>();

        #endregion
    }
}