namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteBookingsViewModel : BaseDeleteViewModel<Booking>
{
    private readonly IBookingFacadeService _bookingService;
    private readonly ITableFacadeService _tableService;

    public DeleteBookingsViewModel(IBookingFacadeService bookingService,
        ITableFacadeService tableService)
    {
        (_bookingService, _tableService) = (bookingService, tableService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    #region Can Execute

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    #endregion

    #region Execute

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        Table? table = await _bookingService.GetBookingTableAsync(id: SelectedGeneralValue.Id);

        if (table is not null)
        {
            (table.Status, table.BookingId) = ("Free", null);

            await _tableService.UpdateAsync(entity: table);
        }

        await _bookingService.DeleteAsync(SelectedGeneralValue.Id);

        MessageBox.Show(
           messageBoxText: "The deletion was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #endregion

    #region Other Logic

    protected override async void Find(string filter)
    {
        var bookings = await _bookingService.GetBookingListAsync();

        filter = filter.ToLower();

        GeneralDataList = bookings.Where(
            predicate: booking =>
            booking.Name.ToLower().Contains(value: filter) |
            booking.Phone.ToLower().Contains(value: filter) |
            booking.Time.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData() => GeneralDataList = await _bookingService.GetBookingListAsync();

    protected override void SelectGeneralValue() { }

    #endregion
}