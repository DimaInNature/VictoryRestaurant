namespace Victory.Consumers.Desktop.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageListQuery
    : BaseAuthorizedFeature, IRequest<List<ContactMessage>?>
{
    public GetContactMessageListQuery(string token) => Token = token;

    public GetContactMessageListQuery() { }
}