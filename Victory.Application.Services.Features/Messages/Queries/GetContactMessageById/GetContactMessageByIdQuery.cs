namespace Victory.Application.Services.Features.Messages;

public sealed record class GetContactMessageByIdQuery : IRequest<ContactMessageEntity?>
{
    public int Id { get; }

    public GetContactMessageByIdQuery(int id) => Id = id;

    public GetContactMessageByIdQuery() { }
}