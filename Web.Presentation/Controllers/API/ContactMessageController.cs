﻿namespace Web.Presentation.Controllers.API;

public class ContactMessageController : Controller
{
    private readonly IContactMessageFacadeService _contactMessageService;

    public ContactMessageController(IContactMessageFacadeService contactMessageService)
    {
        _contactMessageService = contactMessageService;
    }

    [HttpPost("/ContactMessages")]
    public async Task<IActionResult> CreateContactMessage(string name,
        string phone, string email, string message)
    {
        ContactMessage contactMessage = new()
        {
            Mail = email,
            Message = message,
            Name = name,
            Phone = phone
        };

        await _contactMessageService.InsertContactMessageAsync(contactMessage);

        return RedirectToAction(actionName: "Index", controllerName: "Contact");
    }
}