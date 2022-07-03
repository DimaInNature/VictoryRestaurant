namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class GetUserRoleListQuery : IRequest<List<UserRoleEntity>?> { }