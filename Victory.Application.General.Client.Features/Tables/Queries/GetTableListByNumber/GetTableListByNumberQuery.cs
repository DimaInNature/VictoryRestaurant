namespace Victory.Application.General.Client.Features.Tables;

public sealed record class GetTableListByNumberQuery : IRequest<List<Table>?>
{
    public int Number { get; }

    public GetTableListByNumberQuery(int number) => Number = number;

    public GetTableListByNumberQuery() { }
}