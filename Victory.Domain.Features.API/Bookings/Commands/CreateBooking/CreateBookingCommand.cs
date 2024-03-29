﻿namespace Victory.Domain.Features.API.Bookings;

public sealed record class CreateBookingCommand : IRequest
{
    public BookingEntity? Booking { get; }

    public CreateBookingCommand(BookingEntity entity) => Booking = entity;

    public CreateBookingCommand() { }
}