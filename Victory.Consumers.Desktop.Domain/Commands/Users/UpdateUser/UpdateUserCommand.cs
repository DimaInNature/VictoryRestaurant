﻿namespace Victory.Consumers.Desktop.Domain.Commands.Users;

public sealed record class UpdateUserCommand
    : BaseAuthorizedFeature, IRequest
{
    public User? User { get; }

    public UpdateUserCommand(User entity, string token) =>
        (User, Token) = (entity, token);

    public UpdateUserCommand() { }
}