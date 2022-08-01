namespace Victory.Consumers.Desktop.Domain.Commands.MailSubscribers;

public sealed record class DeleteMailSubscriberCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteMailSubscriberCommand(int id, string token) =>
        (Id, Token) = (id, token);

    public DeleteMailSubscriberCommand() { }
}