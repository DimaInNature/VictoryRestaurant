namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class DeleteBookingCommand : IRequest
{
    public int Id { get; }

    public DeleteBookingCommand(int id) => Id = id;

    public DeleteBookingCommand() { }
}