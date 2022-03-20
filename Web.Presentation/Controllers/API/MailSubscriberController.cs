namespace Web.Presentation.Controllers.API;

public class MailSubscriberController : Controller
{
    private readonly IMailSubscriberFacadeService _mailSubscriberService;

    public MailSubscriberController(IMailSubscriberFacadeService mailSubscriberService)
    {
        _mailSubscriberService = mailSubscriberService;
    }

    [HttpPost("/MailSubscribers")]
    public async Task<IActionResult> CreateMailSubscriber(string mail)
    {
        MailSubscriber mailSubscriber = new()
        {
            Mail = mail
        };

        await _mailSubscriberService.InsertMailSubscriberAsync(mailSubscriber);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}