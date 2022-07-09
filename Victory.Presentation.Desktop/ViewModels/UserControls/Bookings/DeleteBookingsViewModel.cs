namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteBookingsViewModel : BaseDeleteViewModel<Booking>
{
    private readonly IBookingFacadeService _bookingService;

    private readonly ITableFacadeService _tableService;

    private readonly UserSessionService _userSessionService;

    public DeleteBookingsViewModel(
        IBookingFacadeService bookingService,
        ITableFacadeService tableService,
        UserSessionService userSessionService)
    {
        (_bookingService, _tableService, _userSessionService) = (bookingService, tableService, userSessionService);

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
        string? token = _userSessionService.JwtToken;

        if (SelectedGeneralValue is null || string.IsNullOrWhiteSpace(value: token)) return;

        Table? table = await _bookingService.GetBookingTableAsync(id: SelectedGeneralValue.Id, token);

        if (table is not null)
        {
            (table.Status, table.BookingId) = ("Free", null);

            await _tableService.UpdateAsync(entity: table);
        }

        await _bookingService.DeleteAsync(SelectedGeneralValue.Id, token);

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
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        var bookings = await _bookingService.GetBookingListAsync(token);

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

    private async Task InitializeData()
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _bookingService.GetBookingListAsync(token);
    }

    protected override void SelectGeneralValue() { }

    #endregion
}