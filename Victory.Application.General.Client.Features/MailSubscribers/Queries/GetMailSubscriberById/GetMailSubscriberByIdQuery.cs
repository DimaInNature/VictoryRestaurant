namespace Victory.Application.General.Client.Features.MailSubscribers;

public sealed record class GetMailSubscriberByIdQuery : IRequest<MailSubscriber?>
{
    public int Id { get; }

    public GetMailSubscriberByIdQuery(int id) => Id = id;

    public GetMailSubscriberByIdQuery() { }
}