namespace Victory.Consumers.Web.Presentation.Controllers.API;

public class MailSubscriberController : Controller
{
    [HttpPost(template: "/MailSubscribers")]
    public async Task<IActionResult> CreateMailSubscriber(
        [FromServices] IMailSubscriberService mailSubscriberService,
        [FromForm] MailSubscriber mailSubscriber)
    {
        await mailSubscriberService.CreateAsync(entity: mailSubscriber);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}