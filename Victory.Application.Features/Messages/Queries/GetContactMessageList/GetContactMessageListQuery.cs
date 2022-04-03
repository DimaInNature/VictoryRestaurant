namespace Victory.Application.Features.Messages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessage>?> { }