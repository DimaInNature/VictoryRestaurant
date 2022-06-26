namespace Victory.Application.General.Client.Features.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessage>?> { }