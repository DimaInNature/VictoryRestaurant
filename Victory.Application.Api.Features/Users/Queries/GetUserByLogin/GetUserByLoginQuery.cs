﻿namespace Victory.Application.API.Features.Users;

public sealed record class GetUserByLoginQuery : IRequest<UserEntity?>
{
    public string? Login { get; }

    public GetUserByLoginQuery(string login) => Login = login;

    public GetUserByLoginQuery() { }
}