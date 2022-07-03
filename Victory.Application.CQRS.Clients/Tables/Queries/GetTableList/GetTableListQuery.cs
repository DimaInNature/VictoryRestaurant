namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class GetTableListQuery : IRequest<List<Table>?> { }