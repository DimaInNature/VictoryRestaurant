namespace Victory.Domain.Features.API.Tables;

public sealed record class GetTableByIdQuery : IRequest<TableEntity?>
{
    public int Id { get; }

    public GetTableByIdQuery(int id) => Id = id;

    public GetTableByIdQuery() { }
}