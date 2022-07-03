namespace Victory.Application.CQRS.Clients.Users;

public sealed record class GetUserListQuery : IRequest<List<User>?> { }