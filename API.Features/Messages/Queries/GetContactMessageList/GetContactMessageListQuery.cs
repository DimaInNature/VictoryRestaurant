namespace API.Features.Messages.Queries;

public sealed record class GetContactMessageListQuery
    : IRequest<List<ContactMessageEntity>?>
{

}