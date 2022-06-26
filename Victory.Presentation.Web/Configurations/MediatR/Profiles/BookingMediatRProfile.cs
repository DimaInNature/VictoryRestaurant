namespace Victory.Presentation.Web.Configurations.MediatR.Profiles;

public static class BookingMediatRProfile
{
    public static void AddBookingMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        // Create

        services.AddScoped<IRequest<Booking?>, CreateBookingCommand>();
        services.AddScoped<IRequestHandler<CreateBookingCommand, Booking?>, CreateBookingCommandHandler>();

        #endregion
    }
}