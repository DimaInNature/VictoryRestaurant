namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteMailSubscribersViewModel
    : BaseDeleteViewModel<MailSubscriber>, IDeleteMailSubscribersViewModel
{
    private readonly IMailSubscriberFacadeService _subscriberService;

    public DeleteMailSubscribersViewModel(IMailSubscriberFacadeService subscriberService)
    {
        _subscriberService = subscriberService;

        InitializeCommands();

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedItem is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedItem is null) return;

        await _subscriberService.DeleteAsync(SelectedItem.Id);

        MessageBox.Show(
           messageBoxText: "Удаление произошло успешно",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

        _lastItemId = null;
    }

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