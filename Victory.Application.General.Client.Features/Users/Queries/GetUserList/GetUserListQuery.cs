namespace Victory.Application.General.Client.Features.Users;

public sealed record class GetUserListQuery : IRequest<List<User>?> { }