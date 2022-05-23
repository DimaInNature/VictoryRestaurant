namespace Victory.Presentation.Mobile.Services.Data.Features.Bookings;

public sealed record class CreateBookingCommandHandler
    : IRequestHandler<CreateBookingCommand>
{
    public async Task<Unit> Handle(CreateBookingCommand request, CancellationToken token)
    {
        try
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(
                requestUri: new Uri(uriString: "http://10.0.2.2:7059/Bookings"));

            webRequest.ContentType = "application/json";

            webRequest.Method = "POST";

            webRequest.Timeout = 4000;

            string sendableObject = JsonConvert.SerializeObject(request.Booking);

            using (StreamWriter streamWriter = new(await webRequest.GetRequestStreamAsync()))
            {
                streamWriter.Write(sendableObject);
                streamWriter.Flush();
                streamWriter.Dispose();
            }

            await webRequest.GetResponseAsync();
        }
        catch { }

        return Unit.Value;
    }
}