namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadTablesViewModel : BaseReadViewModel<Table>
{
    private readonly ITableRepositoryService _repository;

    public ReadTablesViewModel(ITableRepositoryService repository)
    {
        _repository = repository;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected async override void Find(string filter)
    {
        var tables = await _repository.GetTableListAsync();

        filter = filter.ToLower();

        GeneralDataList = tables.Where(
            predicate: table =>
            table.Number.ToString().ToLower().Contains(value: filter) |
            (table.Booking is not null &&
            table.Booking.Name.ToLower().Contains(value: filter) |
            table.Booking.Date.ToString().ToLower().Contains(value: filter) |
            table.Booking.Time.ToLower().Contains(value: filter) |
            table.Booking.Phone.ToLower().Contains(value: filter)))
            .ToList();
    }


    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData() =>
        GeneralDataList = await _repository.GetTableListAsync();

    #endregion
}