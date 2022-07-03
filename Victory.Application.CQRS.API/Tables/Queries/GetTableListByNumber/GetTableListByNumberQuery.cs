namespace Victory.Application.CQRS.API.Tables;

public sealed record class GetTableListByNumberQuery : IRequest<List<TableEntity>?>
{
    public int? Number { get; }

    public GetTableListByNumberQuery(int number) => Number = number;

    public GetTableListByNumberQuery() { }
}