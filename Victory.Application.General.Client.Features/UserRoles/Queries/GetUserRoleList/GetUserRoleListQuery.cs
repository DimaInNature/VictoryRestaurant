namespace Victory.Application.General.Client.Features.UserRoles;

public sealed record class GetUserRoleListQuery : IRequest<List<UserRole>?> { }