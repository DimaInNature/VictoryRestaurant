﻿namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class DeleteBookingCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteBookingCommand(int id, string token) =>
        (Id, Token) = (id, token);

    public DeleteBookingCommand() { }
}