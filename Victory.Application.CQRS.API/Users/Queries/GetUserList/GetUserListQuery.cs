namespace Victory.Application.CQRS.API.Users;

public sealed record class GetUserListQuery : IRequest<List<UserEntity>?> { }