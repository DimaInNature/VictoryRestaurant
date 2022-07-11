namespace Victory.Domain.Features.API.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessageEntity>?> { }