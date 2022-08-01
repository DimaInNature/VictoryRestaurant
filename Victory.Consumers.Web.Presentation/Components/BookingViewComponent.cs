namespace Victory.Consumers.Web.Presentation.Components;

public class BookingViewComponent : ViewComponent
{
    private readonly ITableService _tableService;

    public BookingViewComponent(ITableService tableService) =>
        _tableService = tableService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Table> freeTables = await _tableService.GetTableListAsync(status: "Free");

        ViewBag.IsExistFreeTables = freeTables.Any();

        return View();
    }
}