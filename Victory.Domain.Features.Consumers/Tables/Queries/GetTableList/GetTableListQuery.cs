namespace Victory.Domain.Features.Consumers.Tables;

public sealed record class GetTableListQuery
    : BaseAnonymousFeature, IRequest<List<Table>?>
{ }