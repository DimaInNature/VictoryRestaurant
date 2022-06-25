namespace Victory.Application.API.Features.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessageEntity>?> { }