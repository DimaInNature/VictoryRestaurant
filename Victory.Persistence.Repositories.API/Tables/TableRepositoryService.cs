namespace Victory.Persistence.Repositories.API.Tables;

public class TableRepositoryService : ITableRepositoryService
{
    private readonly IMediator _mediator;

    public TableRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<TableEntity>?> GetTableListAsync() =>
        await _mediator.Send(request: new GetTableListQuery());

    public async Task<List<TableEntity>?> GetTableListAsync(int number) =>
        await _mediator.Send(request: new GetTableListByNumberQuery(number));

    public async Task<List<TableEntity>?> GetTableListAsync(string status) =>
        await _mediator.Send(request: new GetTableListByStatusQuery(status));

    public async Task<TableEntity?> GetTableAsync(int id) =>
        await _mediator.Send(request: new GetTableByIdQuery(id));

    public async Task CreateAsync(TableEntity entity) =>
        await _mediator.Send(request: new CreateTableCommand(entity));

    public async Task UpdateAsync(TableEntity entity) =>
        await _mediator.Send(request: new UpdateTableCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteTableCommand(id));
}