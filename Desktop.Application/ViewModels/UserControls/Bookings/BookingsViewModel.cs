namespace Desktop.Presentation.ViewModels.UserControls.Bookings;

internal sealed class BookingsViewModel
    : BaseViewModel, IBookingsViewModel
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

    public BookingsViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadBookingsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadBookingsView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateBookingsView();

    private void ExecuteShowUpdatePage(object obj) =>
        FrameSource = new UpdateBookingsView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteBookingsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadBookingsView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateBookingsView;

    private bool CanExecuteShowUpdatePage(object obj) =>
        FrameSource is not UpdateBookingsView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteBookingsView;

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