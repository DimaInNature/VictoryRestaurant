namespace Victory.Domain.Features.API.Users;

public sealed record class GetUserListQuery : IRequest<List<UserEntity>?> { }