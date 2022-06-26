namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class GetBookingTableByIdQuery : IRequest<Table?>
{
    public int Id { get; }

    public GetBookingTableByIdQuery(int id) => Id = id;

    public GetBookingTableByIdQuery() { }
}