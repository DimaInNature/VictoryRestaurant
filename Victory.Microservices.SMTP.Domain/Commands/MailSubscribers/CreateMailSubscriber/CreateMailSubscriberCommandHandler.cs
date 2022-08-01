namespace Victory.Microservices.SMTP.Domain.Commands.MailSubscribers;

public sealed record class CreateMailSubscriberCommandHandler
    : IRequestHandler<CreateMailSubscriberCommand>
{
    private readonly IGenericRepository<MailSubscriberEntity> _repository;

    public CreateMailSubscriberCommandHandler(
        IGenericRepository<MailSubscriberEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        CreateMailSubscriberCommand request,
        CancellationToken token)
    {
        if (request.MailSubscriber is null) return Unit.Value;

        await _repository.CreateAsync(entity: request.MailSubscriber, token);

        return Unit.Value;
    }
}