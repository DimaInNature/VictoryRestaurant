namespace Victory.Application.General.Client.Features.Subscribers;

public sealed record class GetMailSubscriberByIdQuery : IRequest<MailSubscriber?>
{
    public int Id { get; }

    public GetMailSubscriberByIdQuery(int id) => Id = id;

    public GetMailSubscriberByIdQuery() { }
}