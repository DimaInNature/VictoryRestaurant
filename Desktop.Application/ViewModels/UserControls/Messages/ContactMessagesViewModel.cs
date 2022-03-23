namespace Desktop.Presentation.ViewModels.UserControls.Messages;

internal sealed class ContactMessagesViewModel
    : BaseViewModel, IContactMessagesViewModel
{
    #region Members

    #region Commands

    public ICommand? ShowReadPageCommand { get; private set; }

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

    public ContactMessagesViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadContactMessagesView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadContactMessagesView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteContactMessagesView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadContactMessagesView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteContactMessagesView;

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