namespace Desktop.Presentation.ViewModels.UserControls.Bookings;

internal sealed class ReadBookingsViewModel
    : BaseReadViewModel<Booking>, IReadBookingsViewModel
{
    private readonly IBookingFacadeService _bookingService;

    public ReadBookingsViewModel(IBookingFacadeService bookingService)
    {
        _bookingService = bookingService;

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Other Logic

    private async Task InitializeData()
    {
        Items = await _bookingService.GetBookingListAsync();
    }

    private async Task AutoUpdateData(int secondsTimeout, bool isEnable)
    {
        // First loading data

        await InitializeData();

        int millisecondsTimeout = secondsTimeout *= 1000;

        while (isEnable)
        {
            Thread.Sleep(millisecondsTimeout: millisecondsTimeout);

            await InitializeData();
        }
    }

    #endregion
}