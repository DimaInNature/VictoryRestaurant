namespace Victory.Presentation.Mobile.Core.Configuration.MediatR.Profiles;

public static class BookingMediatRProfile
{
    public static void AddBookingMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        // Create

        services.AddScoped<IRequest, CreateBookingCommand>();
        services.AddScoped<IRequestHandler<CreateBookingCommand, Unit>, CreateBookingCommandHandler>();

        #endregion
    }
}