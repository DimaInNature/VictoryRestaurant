namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadBookingsViewModel : BaseReadViewModel<Booking>
{
    private readonly IBookingFacadeService _bookingService;

    private readonly UserSessionService _userSessionService;

    public ReadBookingsViewModel(
        IBookingFacadeService bookingService,
        UserSessionService userSessionService)
    {
        (_bookingService, _userSessionService) = (bookingService, userSessionService);

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        var bookings = await _bookingService.GetBookingListAsync(token);

        filter = filter.ToLower();

        GeneralDataList = bookings.Where(predicate:
            booking => booking.Name.Contains(value: filter) |
            booking.Phone.Contains(value: filter) | booking.Time.Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData()
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _bookingService.GetBookingListAsync(token);
    }

    #endregion
}