namespace Desktop.Presentation.ViewModels.UserControls.Subscribers;

internal sealed class MailSubscribersViewModel
    : BaseViewModel, IMailSubscribersViewModel
{
    #region Members

    #region Commands

    public ICommand? ShowReadPageCommand { get; private set; }

    public ICommand? ShowCreatePageCommand { get; private set; }

    public ICommand? ShowUpdatePageCommand { get; private set; }

    public ICommand? ShowDeletePageCommand { get; private set; }

    #endregion

    #region View

    public object? FrameSource
    {
        get => _frameSource;
        set
        {
            _frameSource = value;

            OnPropertyChanged(nameof(FrameSource));
        }
    }

    #endregion

    #region Private

    private object? _frameSource;

    #endregion

    #endregion

    public MailSubscribersViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadMailSubscribersView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadMailSubscribersView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateMailSubscribersView();

    private void ExecuteShowUpdatePage(object obj) =>
        FrameSource = new UpdateMailSubscribersView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteMailSubscribersView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadMailSubscribersView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateMailSubscribersView;

    private bool CanExecuteShowUpdatePage(object obj) =>
        FrameSource is not UpdateMailSubscribersView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteMailSubscribersView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowReadPageCommand = new RelayCommand(executeAction: ExecuteShowReadPage,
            canExecuteFunc: CanExecuteShowReadPage);

        ShowCreatePageCommand = new RelayCommand(executeAction: ExecuteShowCreatePage,
           canExecuteFunc: CanExecuteShowCreatePage);

        ShowUpdatePageCommand = new RelayCommand(executeAction: ExecuteShowUpdatePage,
            canExecuteFunc: CanExecuteShowUpdatePage);

        ShowDeletePageCommand = new RelayCommand(executeAction: ExecuteShowDeletePage,
            canExecuteFunc: CanExecuteDeletePage);
    }

    #endregion
}