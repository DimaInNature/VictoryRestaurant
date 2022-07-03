namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableListByStatusQuery : IRequest<List<Table>>
{
    public string Status { get; }

    public GetTableListByStatusQuery(string status) => Status = status;

    public GetTableListByStatusQuery() { }
}