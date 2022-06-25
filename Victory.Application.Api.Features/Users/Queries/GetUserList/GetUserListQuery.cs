namespace Victory.Application.API.Features.Users;

public sealed record class GetUserListQuery : IRequest<List<UserEntity>?> { }