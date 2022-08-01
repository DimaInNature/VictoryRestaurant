namespace Victory.Consumers.Desktop.Domain.Queries.Tables;

public sealed record class GetTableListQuery
    : BaseAnonymousFeature, IRequest<List<Table>?>
{ }