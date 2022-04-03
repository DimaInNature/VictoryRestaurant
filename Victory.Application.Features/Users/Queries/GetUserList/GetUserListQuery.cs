namespace Victory.Application.Features.Users;

public sealed record class GetUserListQuery : IRequest<List<User>?> { }