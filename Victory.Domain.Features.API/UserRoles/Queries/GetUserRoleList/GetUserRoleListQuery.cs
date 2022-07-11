namespace Victory.Domain.Features.API.UserRoles;

public sealed record class GetUserRoleListQuery : IRequest<List<UserRoleEntity>?> { }