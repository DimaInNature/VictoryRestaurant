﻿namespace Web.Presentation.Components;

public class PageHeadingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string heading, string text)
    {
        ViewBag.Heading = heading;
        ViewBag.Text = text;

        return View();
    }
}