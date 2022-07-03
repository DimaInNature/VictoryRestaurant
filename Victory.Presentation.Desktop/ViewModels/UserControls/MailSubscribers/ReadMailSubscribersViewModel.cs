namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal class ReadMailSubscribersViewModel : BaseReadViewModel<MailSubscriber>
{
    private readonly IMailSubscriberFacadeService _subscriberService;

    public ReadMailSubscribersViewModel(IMailSubscriberFacadeService subscriberService)
    {
        _subscriberService = subscriberService;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        var subscribers = await _subscriberService.GetMailSubscriberListAsync();

        filter = filter.ToLower();

        GeneralDataList = subscribers.Where(
            predicate: subscriber =>
            subscriber.Mail.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData() =>
        GeneralDataList = await _subscriberService.GetMailSubscriberListAsync();

    #endregion
}