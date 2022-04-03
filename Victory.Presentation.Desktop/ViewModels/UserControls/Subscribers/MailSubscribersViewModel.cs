namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class MailSubscribersViewModel
    : BaseMenuViewModel, IMailSubscribersViewModel
{
    public MailSubscribersViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadMailSubscribersView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadMailSubscribersView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteMailSubscribersView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadMailSubscribersView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteMailSubscribersView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowReadPageCommand = new RelayCommand(executeAction: ExecuteShowReadPage,
            canExecuteFunc: CanExecuteShowReadPage);

        ShowDeletePageCommand = new RelayCommand(executeAction: ExecuteShowDeletePage,
            canExecuteFunc: CanExecuteDeletePage);
    }

    #endregion
}