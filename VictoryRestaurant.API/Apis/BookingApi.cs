﻿namespace VictoryRestaurant.API.Apis;

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

    private async Task<IResult> GetAll(IBookingRepositoryService repository)
        => Results.Ok(await repository.GetBookingsAsync());

    private async Task<IResult> GetById(int id, IBookingRepositoryService repository)
        => await repository.GetBookingAsync(bookingId: id) is BookingEntity booking
        ? Results.Ok(booking)
        : Results.NotFound();

    private async Task<IResult> Create([FromBody] BookingEntity booking, IBookingRepositoryService repository)
    {
        await repository.InsertBookingAsync(booking);
        await repository.SaveAsync();
        return Results.Created($"/Bookings/{booking.Id}", booking);
    }

    private async Task<IResult> Put([FromBody] BookingEntity booking, IBookingRepositoryService repository)
    {
        await repository.UpdateBookingAsync(booking);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(int id, IBookingRepositoryService repository)
    {
        await repository.DeleteBookingAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}
