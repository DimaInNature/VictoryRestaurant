namespace Victory.Application.CQRS.API.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessageEntity>?> { }