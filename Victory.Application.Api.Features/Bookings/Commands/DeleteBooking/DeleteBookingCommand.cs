namespace Victory.Application.API.Features.Bookings;

public sealed record class DeleteBookingCommand : IRequest
{
    public int Id { get; }

    public DeleteBookingCommand(int id) => Id = id;

    public DeleteBookingCommand() { }
}