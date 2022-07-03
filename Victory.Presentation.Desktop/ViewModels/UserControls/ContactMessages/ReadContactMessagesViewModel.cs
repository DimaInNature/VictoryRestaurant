namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadContactMessagesViewModel : BaseReadViewModel<ContactMessage>
{
    private readonly IContactMessageFacadeService _messageService;

    public ReadContactMessagesViewModel(IContactMessageFacadeService messageService)
    {
        _messageService = messageService;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        var messages = await _messageService.GetContactMessageListAsync();

        filter = filter.ToLower();

        GeneralDataList = messages.Where(
            predicate: message =>
            message.Mail.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData() =>
        GeneralDataList = await _messageService.GetContactMessageListAsync();

    #endregion
}