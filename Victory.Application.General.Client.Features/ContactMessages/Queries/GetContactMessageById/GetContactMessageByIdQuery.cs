namespace Victory.Application.General.Client.Features.ContactMessages;

public sealed record class GetContactMessageByIdQuery : IRequest<ContactMessage>
{
    public int Id { get; }

    public GetContactMessageByIdQuery(int id) => Id = id;

    public GetContactMessageByIdQuery() { }
}