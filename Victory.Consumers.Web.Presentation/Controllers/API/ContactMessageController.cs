namespace Victory.Consumers.Web.Presentation.Controllers.API;

public class ContactMessageController : Controller
{
    [HttpPost(template: "/ContactMessages")]
    public async Task<IActionResult> CreateContactMessage(
        [FromServices] IContactMessageService contactMessageService,
        [FromForm] ContactMessage contactMessage)
    {
        await contactMessageService.CreateAsync(contactMessage);

        return RedirectToAction(actionName: "Index", controllerName: "Contact");
    }
}