namespace Victory.Application.CQRS.API.Tables;

public sealed record class GetTableListQuery : IRequest<List<TableEntity>?> { }