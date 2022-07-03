namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadBookingsViewModel : BaseReadViewModel<Booking>
{
    private readonly IBookingFacadeService _bookingService;

    public ReadBookingsViewModel(IBookingFacadeService bookingService)
    {
        _bookingService = bookingService;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        var bookings = await _bookingService.GetBookingListAsync();

        filter = filter.ToLower();

        GeneralDataList = bookings.Where(predicate:
            booking => booking.Name.Contains(value: filter) |
            booking.Phone.Contains(value: filter) | booking.Time.Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData() =>
       GeneralDataList = await _bookingService.GetBookingListAsync();

    #endregion
}