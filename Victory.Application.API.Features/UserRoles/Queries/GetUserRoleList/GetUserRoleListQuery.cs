namespace Victory.Application.API.Features.UserRoles;

public sealed record class GetUserRoleListQuery : IRequest<List<UserRoleEntity>?> { }