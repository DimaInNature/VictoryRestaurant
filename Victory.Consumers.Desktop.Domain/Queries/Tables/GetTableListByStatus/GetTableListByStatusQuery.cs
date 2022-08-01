namespace Victory.Consumers.Desktop.Domain.Queries.Tables;

public sealed record class GetTableListByStatusQuery
    : BaseAnonymousFeature, IRequest<List<Table>>
{
    public string? Status { get; }

    public GetTableListByStatusQuery(string status) => Status = status;

    public GetTableListByStatusQuery() { }
}