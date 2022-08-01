namespace Victory.Consumers.Web.Application.Services.Tables;

public class TableService : ITableService
{
    private readonly IMediator _mediator;

    public TableService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<Table?> GetTableAsync(int id, string token) =>
        await _mediator.Send(request: new GetTableByIdQuery(id, token));

    public async Task<List<Table>> GetTableListAsync() =>
        await _mediator.Send(request: new GetTableListQuery()) ?? new();

    public async Task<List<Table>> GetTableListAsync(int number) =>
        await _mediator.Send(request: new GetTableListByNumberQuery(number)) ?? new();

    public async Task<List<Table>> GetTableListAsync(string status) =>
        await _mediator.Send(request: new GetTableListByStatusQuery(status));

    public async Task CreateAsync(Table entity, string token) =>
        await _mediator.Send(request: new CreateTableCommand(entity, token));

    public async Task UpdateAsync(Table entity) =>
        await _mediator.Send(request: new UpdateTableCommand(entity));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteTableCommand(id, token));
}