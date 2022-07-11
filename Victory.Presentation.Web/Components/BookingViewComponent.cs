namespace Victory.Presentation.Web.Components;

public class BookingViewComponent : ViewComponent
{
    private readonly ITableFacadeService _tableService;

    public BookingViewComponent(ITableFacadeService tableService) =>
        _tableService = tableService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Table> freeTables = await _tableService.GetTableListAsync(status: "Free");

        ViewBag.IsExistFreeTables = freeTables.Any();

        return View();
    }
}