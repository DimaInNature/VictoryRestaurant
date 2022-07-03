namespace Victory.Application.CQRS.API.Users;

public sealed record class GetUserByIdQuery : IRequest<UserEntity>
{
    public int Id { get; }

    public GetUserByIdQuery(int id) => Id = id;

    public GetUserByIdQuery() { }
}