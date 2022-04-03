﻿namespace Victory.Application.Features.Users;

public sealed record class CreateUserCommand : IRequest
{
    public User? User { get; }

    public CreateUserCommand(User entity) => User = entity;

    public CreateUserCommand() { }
}