namespace Victory.Microservices.SMTP.Domain.Commands.MailSubscribers;

public sealed record class DeleteMailSubscriberCommandHandler
    : IRequestHandler<DeleteMailSubscriberCommand>
{
    private readonly IGenericRepository<MailSubscriberEntity> _repository;

    public DeleteMailSubscriberCommandHandler(
        IGenericRepository<MailSubscriberEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        DeleteMailSubscriberCommand request,
        CancellationToken token)
    {
        if (request.Id < 1) return Unit.Value;

        await _repository.DeleteAsync(id: request.Id, token);

        return Unit.Value;
    }
}