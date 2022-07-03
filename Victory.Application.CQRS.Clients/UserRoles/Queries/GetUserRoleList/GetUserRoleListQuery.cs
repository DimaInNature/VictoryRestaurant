namespace Victory.Application.CQRS.Clients.UserRoles;

public sealed record class GetUserRoleListQuery : IRequest<List<UserRole>?> { }