﻿namespace Victory.Domain.Features.API.UserRoles;

public sealed record class DeleteUserRoleCommand : IRequest
{
    public int Id { get; }

    public DeleteUserRoleCommand(int id) => Id = id;

    public DeleteUserRoleCommand() { }
}