namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableListByNumberQuery
    : BaseAnonymousFeature, IRequest<List<Table>?>
{
    public int Number { get; }

    public GetTableListByNumberQuery(int number) => Number = number;

    public GetTableListByNumberQuery() { }
}