namespace Victory.Application.General.Client.Features.Tables;

public sealed record class GetTableListQuery : IRequest<List<Table>?> { }