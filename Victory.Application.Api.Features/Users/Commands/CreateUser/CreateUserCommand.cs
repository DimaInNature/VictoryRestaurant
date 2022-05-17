﻿namespace Victory.Application.Api.Features.Users;

public sealed record class CreateUserCommand : IRequest
{
    public UserEntity? User { get; }

    public CreateUserCommand(UserEntity entity) => User = entity;

    public CreateUserCommand() { }
}