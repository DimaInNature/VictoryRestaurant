namespace Victory.Application.Api.Features.Subscribers;

public sealed record class GetMailSubscriberByIdQuery : IRequest<MailSubscriberEntity?>
{
    public int Id { get; }

    public GetMailSubscriberByIdQuery(int id) => Id = id;

    public GetMailSubscriberByIdQuery() { }
}