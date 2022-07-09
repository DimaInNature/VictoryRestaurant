namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableListQuery
    : BaseAnonymousFeature, IRequest<List<Table>?>
{ }