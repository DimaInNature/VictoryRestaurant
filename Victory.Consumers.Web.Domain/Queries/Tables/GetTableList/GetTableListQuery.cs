namespace Victory.Consumers.Web.Domain.Queries.Tables;

public sealed record class GetTableListQuery
    : BaseAnonymousFeature, IRequest<List<Table>?>
{ }
