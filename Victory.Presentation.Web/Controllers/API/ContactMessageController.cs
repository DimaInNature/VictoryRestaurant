namespace Victory.Presentation.Web.Controllers.API;

public class ContactMessageController : Controller
{
    [HttpPost("/ContactMessages")]
    public async Task<IActionResult> CreateContactMessage(
        [FromServices] IContactMessageRepositoryService contactMessageService,
        [FromForm] ContactMessage contactMessage)
    {
        await contactMessageService.CreateAsync(contactMessage);

        return RedirectToAction(actionName: "Index", controllerName: "Contact");
    }
}