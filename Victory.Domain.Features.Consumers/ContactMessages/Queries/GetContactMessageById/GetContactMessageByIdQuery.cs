namespace Victory.Domain.Features.Consumers.ContactMessages;

public sealed record class GetContactMessageByIdQuery
    : BaseAuthorizedFeature, IRequest<ContactMessage>
{
    public int Id { get; }

    public GetContactMessageByIdQuery(int id, string token) =>
        (Id, Token) = (id, token);

    public GetContactMessageByIdQuery() { }
}