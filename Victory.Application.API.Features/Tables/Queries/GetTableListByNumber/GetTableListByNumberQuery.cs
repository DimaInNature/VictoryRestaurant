namespace Victory.Application.API.Features.Tables;

public sealed record class GetTableListByNumberQuery : IRequest<List<TableEntity>?>
{
    public int? Number { get; }

    public GetTableListByNumberQuery(int number) => Number = number;

    public GetTableListByNumberQuery() { }
}