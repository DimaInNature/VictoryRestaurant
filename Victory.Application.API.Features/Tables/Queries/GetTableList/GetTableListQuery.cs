namespace Victory.Application.API.Features.Tables;

public sealed record class GetTableListQuery : IRequest<List<TableEntity>?> { }