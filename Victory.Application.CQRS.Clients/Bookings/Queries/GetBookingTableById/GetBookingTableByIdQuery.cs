namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class GetBookingTableByIdQuery
    : BaseAuthorizedFeature, IRequest<Table?>
{
    public int Id { get; }

    public GetBookingTableByIdQuery(int id, string token) =>
        (Id, Token) = (id, token);

    public GetBookingTableByIdQuery() { }
}