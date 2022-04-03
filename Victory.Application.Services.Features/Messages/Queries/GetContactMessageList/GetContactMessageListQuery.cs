namespace Victory.Application.Services.Features.Messages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessageEntity>?> { }