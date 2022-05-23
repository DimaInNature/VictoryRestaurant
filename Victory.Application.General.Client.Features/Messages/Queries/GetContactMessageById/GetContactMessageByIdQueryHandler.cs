namespace Victory.Application.General.Client.Features.Messages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>
{
    public async Task<ContactMessage?> Handle(GetContactMessageByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"http://localhost:7059/Bookings/{request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<ContactMessage>(value: apiResponse);
    }
}