namespace Web.Presentation.Controllers.API;

public class MailSubscriberController : Controller
{
    private readonly IMailSubscriberFacadeService _mailSubscriberService;

    public MailSubscriberController(IMailSubscriberFacadeService mailSubscriberService)
    {
        _mailSubscriberService = mailSubscriberService;
    }

    [HttpPost("/MailSubscribers")]
    public async Task<IActionResult> CreateMailSubscriber(string email)
    {
        MailSubscriber mailSubscriber = new()
        {
            Mail = email
        };

        await _mailSubscriberService.InsertMailSubscriberAsync(mailSubscriber);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}