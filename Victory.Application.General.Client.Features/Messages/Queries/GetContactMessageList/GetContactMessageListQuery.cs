namespace Victory.Application.General.Client.Features.Messages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessage>?> { }