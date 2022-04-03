namespace Victory.Application.Services.Features.Users;

public sealed record class GetUserListQuery : IRequest<List<UserEntity>?> { }