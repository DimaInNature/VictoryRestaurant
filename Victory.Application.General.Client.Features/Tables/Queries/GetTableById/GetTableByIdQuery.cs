namespace Victory.Application.General.Client.Features.Tables;

public sealed record class GetTableByIdQuery : IRequest<Table?>
{
    public int Id { get; }

    public GetTableByIdQuery(int id) => Id = id;

    public GetTableByIdQuery() { }
}