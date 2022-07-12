namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadContactMessagesViewModel : BaseReadViewModel<ContactMessage>
{
    private readonly IContactMessageRepositoryService _messageService;

    private readonly UserSessionService _userSessionService;

    public ReadContactMessagesViewModel(
        IContactMessageRepositoryService messageService,
        UserSessionService userSessionService)
    {
        (_messageService, _userSessionService) = (messageService, userSessionService);

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        var messages = await _messageService.GetContactMessageListAsync(token);

        filter = filter.ToLower();

        GeneralDataList = messages.Where(
            predicate: message =>
            message.Mail.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData()
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _messageService.GetContactMessageListAsync(token);
    }

    #endregion
}