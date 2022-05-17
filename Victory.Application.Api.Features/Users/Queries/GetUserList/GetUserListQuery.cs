namespace Victory.Application.Api.Features.Users;

public sealed record class GetUserListQuery : IRequest<List<UserEntity>?> { }