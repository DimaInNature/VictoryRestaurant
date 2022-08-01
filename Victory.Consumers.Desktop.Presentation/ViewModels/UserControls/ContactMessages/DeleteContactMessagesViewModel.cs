namespace Victory.Consumers.Desktop.Presentation.ViewModels;

internal sealed class DeleteContactMessagesViewModel : BaseDeleteViewModel<ContactMessage>
{
    private readonly IContactMessageService _messageService;

    private readonly UserSessionService _userSessionService;

    public DeleteContactMessagesViewModel(
        IContactMessageService messageService,
        UserSessionService userSessionService)
    {
        (_messageService, _userSessionService) = (messageService, userSessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        string? token = _userSessionService.JwtToken;

        if (SelectedGeneralValue is null || string.IsNullOrWhiteSpace(value: token)) return;

        await _messageService.DeleteAsync(id: SelectedGeneralValue.Id, token);

        MessageBox.Show(
           messageBoxText: "The deletion was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

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

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData()
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(value: token)) return;

        GeneralDataList = await _messageService.GetContactMessageListAsync(token);
    }
    #endregion
}