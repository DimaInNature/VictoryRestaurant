namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteTablesViewModel : BaseDeleteViewModel<Table>
{
    private readonly ITableFacadeService _tableRepository;

    public DeleteTablesViewModel(ITableFacadeService tableRepository)
    {
        _tableRepository = tableRepository;

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        await _tableRepository.DeleteAsync(SelectedGeneralValue.Id);

        MessageBox.Show(
           messageBoxText: "The deletion was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override async void Find(string filter)
    {
        var tables = await _tableRepository.GetTableListAsync();

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

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData() =>
        GeneralDataList = await _tableRepository.GetTableListAsync();

    #endregion
}