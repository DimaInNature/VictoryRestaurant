﻿namespace Victory.Persistence.Repositories.API.Users;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IMediator _mediator;

    public UserRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<UserEntity>?> GetUserListAsync() =>
        await _mediator.Send(request: new GetUserListQuery());

    public async Task<UserEntity?> GetUserAsync(int id) =>
         await _mediator.Send(request: new GetUserByIdQuery(id));

    public async Task<UserEntity?> GetUserAsync(string login) =>
         await _mediator.Send(request: new GetUserByLoginQuery(login));

    public async Task<UserEntity?> GetUserAsync(UserLogin userLogin) =>
        await _mediator.Send(request: new GetUserByLoginAndPasswordQuery(userLogin));

    public async Task CreateAsync(UserEntity entity) =>
         await _mediator.Send(request: new CreateUserCommand(entity));

    public async Task UpdateAsync(UserEntity entity) =>
        await _mediator.Send(request: new UpdateUserCommand(entity));

    public async Task DeleteAsync(int entity) =>
        await _mediator.Send(request: new DeleteUserCommand(entity));
}