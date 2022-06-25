namespace Victory.Application.API.Features.Bookings;

public sealed record class GetBookingTableByIdQuery : IRequest<TableEntity?>
{
    public int Id { get; }

    public GetBookingTableByIdQuery(int id) => Id = id;

    public GetBookingTableByIdQuery() { }
}