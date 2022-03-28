namespace Desktop.Presentation.ViewModels.UserControls.Subscribers;

internal class ReadMailSubscribersViewModel
    : BaseReadViewModel<MailSubscriber>, IReadMailSubscribersViewModel
{
    private readonly IMailSubscriberFacadeService _subscriberService;

    public ReadMailSubscribersViewModel(IMailSubscriberFacadeService subscriberService)
    {
        _subscriberService = subscriberService;

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Other Logic

    private async Task InitializeData()
    {
        Items = await _subscriberService.GetMailSubscriberListAsync();
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