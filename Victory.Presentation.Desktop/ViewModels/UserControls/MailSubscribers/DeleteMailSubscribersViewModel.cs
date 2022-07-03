namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteMailSubscribersViewModel : BaseDeleteViewModel<MailSubscriber>
{
    private readonly IMailSubscriberFacadeService _subscriberService;

    public DeleteMailSubscribersViewModel(IMailSubscriberFacadeService subscriberService)
    {
        _subscriberService = subscriberService;

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedGeneralValue is null) return;

        await _subscriberService.DeleteAsync(SelectedGeneralValue.Id);

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
        var subscribers = await _subscriberService.GetMailSubscriberListAsync();

        filter = filter.ToLower();

        GeneralDataList = subscribers.Where(
            predicate: subscriber =>
            subscriber.Mail.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData() =>
        GeneralDataList = await _subscriberService.GetMailSubscriberListAsync();

    #endregion
}