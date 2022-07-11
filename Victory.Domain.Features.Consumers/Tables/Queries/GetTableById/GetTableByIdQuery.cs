namespace Victory.Domain.Features.Consumers.Tables;

public sealed record class GetTableByIdQuery
    : BaseAuthorizedFeature, IRequest<Table?>
{
    public int Id { get; }

    public GetTableByIdQuery(int id, string token) => (Id, Token) = (id, token);

    public GetTableByIdQuery() { }
}