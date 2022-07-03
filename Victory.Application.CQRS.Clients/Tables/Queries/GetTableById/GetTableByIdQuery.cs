namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableByIdQuery : IRequest<Table?>
{
    public int Id { get; }

    public GetTableByIdQuery(int id) => Id = id;

    public GetTableByIdQuery() { }
}