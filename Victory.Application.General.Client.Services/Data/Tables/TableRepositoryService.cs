﻿namespace Victory.Application.General.Client.Services.Data.Tables;

public class TableRepositoryService : ITableRepositoryService
{
    private readonly IMediator _mediator;

    public TableRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<Table?> GetTableAsync(int id) =>
        await _mediator.Send(request: new GetTableByIdQuery(id));

    public async Task<List<Table>?> GetTableListAsync() =>
        await _mediator.Send(request: new GetTableListQuery());

    public async Task<List<Table>?> GetTableListAsync(int number) =>
        await _mediator.Send(request: new GetTableListByNumberQuery(number));

    public async Task<List<Table>?> GetTableListAsync(bool status) =>
        await _mediator.Send(request: new GetTableListByStatusQuery(status));

    public async Task CreateAsync(Table entity) =>
        await _mediator.Send(request: new CreateTableCommand(entity));

    public async Task UpdateAsync(Table entity) =>
        await _mediator.Send(request: new UpdateTableCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteTableCommand(id));
}