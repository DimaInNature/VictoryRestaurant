﻿namespace Victory.Application.Services.Features.Users;

public sealed record class UpdateUserCommand : IRequest
{
    public UserEntity? User { get; }

    public UpdateUserCommand(UserEntity user) => User = user;

    public UpdateUserCommand() { }
}