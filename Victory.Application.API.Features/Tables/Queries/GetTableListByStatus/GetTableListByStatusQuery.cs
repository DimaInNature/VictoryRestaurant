namespace Victory.Application.API.Features.Tables;

public sealed record class GetTableListByStatusQuery : IRequest<List<TableEntity>?>
{
    public string? Status { get; }

    public GetTableListByStatusQuery(string status) => Status = status;

    public GetTableListByStatusQuery() { }
}