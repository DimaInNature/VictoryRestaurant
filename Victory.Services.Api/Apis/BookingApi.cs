namespace Victory.Services.Api;

public class BookingApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet(pattern: "/Bookings", handler: GetAll)
            .Produces<List<BookingEntity>>(StatusCodes.Status200OK)
            .WithName("GetAllBookings")
            .WithTags("Getters");

        app.MapGet(pattern: "/Bookings/{id}", handler: GetById)
            .Produces<BookingEntity>(StatusCodes.Status200OK)
            .WithName("GetBooking")
            .WithTags("Getters");

        app.MapPost(pattern: "/Bookings", handler: Create)
            .Accepts<BookingEntity>("application/json")
            .Produces<BookingEntity>(StatusCodes.Status201Created)
            .WithName("CreateBooking")
            .WithTags("Creators");

        app.MapPut(pattern: "/Bookings", handler: Put)
            .Accepts<BookingEntity>("application/json")
            .WithName("UpdateBooking")
            .WithTags("Updaters");

        app.MapDelete(pattern: "/Bookings/{id}", handler: Delete)
            .WithName("DeleteBooking")
            .WithTags("Deleters");
    }

    private async Task<IResult> GetAll(IBookingFacadeService repository)
        => Results.Ok(await repository.GetBookingListAsync());

    private async Task<IResult> GetById(int id, IBookingFacadeService repository)
        => await repository.GetBookingAsync(bookingId: id) is BookingEntity booking
        ? Results.Ok(booking)
        : Results.NotFound();

    private async Task<IResult> Create([FromBody] BookingEntity booking,
        IBookingFacadeService repository)
    {
        await repository.CreateAsync(booking);

        return Results.Created($"/Bookings/{booking.Id}", booking);
    }

    private async Task<IResult> Put([FromBody] BookingEntity booking,
        IBookingFacadeService repository)
    {
        await repository.UpdateAsync(booking);

        return Results.NoContent();
    }

    private async Task<IResult> Delete(int id, IBookingFacadeService repository)
    {
        await repository.DeleteAsync(id);

        return Results.NoContent();
    }
}