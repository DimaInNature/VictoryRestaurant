namespace Victory.Consumers.Desktop.Presentation.ViewModels;

internal class ReadMailSubscribersViewModel : BaseReadViewModel<MailSubscriber>
{
    private readonly IMailSubscriberService _subscriberService;

    private readonly UserSessionService _userSessionService;

    public ReadMailSubscribersViewModel(
        IMailSubscriberService subscriberService,
        UserSessionService userSessionService)
    {
        (_subscriberService, _userSessionService) = (subscriberService, userSessionService);

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

    private async Task InitializeData()
    {
        GeneralDataList = await _subscriberService.GetMailSubscriberListAsync();
    }

    #endregion
}