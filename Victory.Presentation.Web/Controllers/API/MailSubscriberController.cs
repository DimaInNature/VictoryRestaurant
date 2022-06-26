namespace Victory.Presentation.Web.Controllers.API;

public class MailSubscriberController : Controller
{
    [HttpPost("/MailSubscribers")]
    public async Task<IActionResult> CreateMailSubscriber(
        [FromServices] IMailSubscriberFacadeService mailSubscriberService,
        [FromForm] MailSubscriber mailSubscriber)
    {
        await mailSubscriberService.CreateAsync(entity: mailSubscriber);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}