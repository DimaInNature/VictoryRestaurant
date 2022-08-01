namespace Victory.Microservices.SMTP.Domain.Commands.MailSubscribers;

public sealed record class UpdateMailSubscriberCommandHandler
    : IRequestHandler<UpdateMailSubscriberCommand>
{
    private readonly IGenericRepository<MailSubscriberEntity> _repository;

    public UpdateMailSubscriberCommandHandler(
        IGenericRepository<MailSubscriberEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        UpdateMailSubscriberCommand request,
        CancellationToken token)
    {
        if (request.MailSubscriber is null) return Unit.Value;

        await _repository.UpdateAsync(entity: request.MailSubscriber, token);

        return Unit.Value;
    }
}