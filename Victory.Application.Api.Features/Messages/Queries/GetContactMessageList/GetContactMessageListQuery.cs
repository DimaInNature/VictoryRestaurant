namespace Victory.Application.Api.Features.Messages;

public sealed record class GetContactMessageListQuery : IRequest<List<ContactMessageEntity>?> { }