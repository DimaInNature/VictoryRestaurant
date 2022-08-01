namespace Victory.Consumers.Desktop.Presentation.ViewModels;

internal sealed class UpdateTablesViewModel : BaseUpdateViewModel<Table>
{
    private readonly ITableService _tableService;

    public UpdateTablesViewModel(ITableService tableService)
    {
        _tableService = tableService;

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedGeneralValue is not null && SelectedGeneralValue.Number > 0;

    protected override async void ExecuteUpdateCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        var tables = await _tableService.GetTableListAsync(number: SelectedGeneralValue.Number);

        if (tables.Count > 0)
        {
            MessageBox.Show(
                messageBoxText: "The table already exists",
                caption: "Information",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        await _tableService.UpdateAsync(SelectedGeneralValue);

        MessageBox.Show(
           messageBoxText: "The change was successful",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override async void Find(string filter)
    {
        var tables = await _tableService.GetTableListAsync();

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

    protected override async Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private void InitializeCommands()
    {
        UpdateCommand = new RelayCommand(executeAction: ExecuteUpdateCommand,
            canExecuteFunc: CanExecuteUpdateCommand);
    }

    private async Task InitializeData()
    {
        GeneralDataList = await _tableService.GetTableListAsync();
    }

    #endregion
}