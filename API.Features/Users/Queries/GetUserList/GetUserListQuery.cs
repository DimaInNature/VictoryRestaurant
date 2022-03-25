namespace API.Features.Users.Queries;

public sealed record class GetUserListQuery : IRequest<List<UserEntity>?>
{

}