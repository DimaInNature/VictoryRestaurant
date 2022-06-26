namespace Victory.Application.General.Client.Features.Tables;

public sealed record class GetTableListByStatusQuery : IRequest<List<Table>?>
{
    public bool Status { get; }

    public GetTableListByStatusQuery(bool status) => Status = status;

    public GetTableListByStatusQuery() { }
}