namespace Victory.Domain.Features.API.Tables;

public sealed record class GetTableListQuery : IRequest<List<TableEntity>?> { }