namespace Victory.Application.CQRS.Clients.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessage>?> { }