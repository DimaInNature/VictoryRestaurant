namespace Victory.Presentation.Desktop.ViewModels;

internal sealed class MainViewModel
    : BaseViewModel, IMainViewModel
{
    #region Members

    #region Commands

    public ICommand? ShowHomePageCommand { get; private set; }

    public ICommand? ShowFoodsPageCommand { get; private set; }

    public ICommand? ShowUsersPageCommand { get; private set; }

    public ICommand? ShowBookingsPageCommand { get; private set; }

    public ICommand? ShowMailSubscribersPageCommand { get; private set; }

    public ICommand? ShowContactMessagesPageCommand { get; private set; }

    #endregion

    #region View

    public Visibility FrameVisibility
    {
        get => _frameVisibility;
        set
        {
            _frameVisibility = value;
            OnPropertyChanged(nameof(FrameVisibility));
        }
    }

    public object? FrameSource
    {
        get => _frameSource;
        set
        {
            _frameSource = value;

            OnPropertyChanged(nameof(FrameSource));

            MenuIsVisible = value switch
            {
                null => Visibility.Visible,
                _ => Visibility.Collapsed,
            };
        }
    }

    public Visibility MenuIsVisible
    {
        get => _menuIsVisible;
        set
        {
            _menuIsVisible = value;
            OnPropertyChanged(nameof(MenuIsVisible));
        }
    }

    #endregion

    #region Private

    private Visibility _frameVisibility;

    private object? _frameSource;

    private Visibility _menuIsVisible;

    #endregion

    #region Dependencies

    private readonly UserSessionService _sessionService;

    #endregion

    #endregion

    public MainViewModel(UserSessionService sessionService)
    {
        _sessionService = sessionService;

        InitializeCommands();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowFoodsPage(object obj) =>
        FrameSource = new FoodsView();

    private void ExecuteShowHomePage(object obj) =>
        FrameSource = null;

    private void ExecuteShowBookingsPage(object obj) =>
        FrameSource = new BookingsView();

    private void ExecuteShowUsersPage(object obj) =>
        FrameSource = new UsersView();

    private void ExecuteShowMailSubscribersPage(object obj) =>
        FrameSource = new MailSubscribersView();

    private void ExecuteShowContactMessagesPage(object obj) =>
        FrameSource = new ContactMessagesView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowHomePage(object obj) =>
        !(FrameSource is null && MenuIsVisible is Visibility.Visible);

    private bool CanExecuteShowFoodsPage(object obj) =>
        FrameSource is not FoodsView;

    private bool CanExecuteShowBookingsPage(object obj) =>
        FrameSource is not BookingsView;

    private bool CanExecuteShowUsersPage(object obj) =>
        FrameSource is not UsersView && _sessionService?.ActiveUser?.Role is UserRole.Admin;

    private bool CanExecuteShowMailSubscribersPage(object obj) =>
        FrameSource is not MailSubscribersView;

    private bool CanExecuteShowContactMessagesPage(object obj) =>
        FrameSource is not ContactMessagesView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowHomePageCommand = new RelayCommand(executeAction: ExecuteShowHomePage,
            canExecuteFunc: CanExecuteShowHomePage);

        ShowFoodsPageCommand = new RelayCommand(executeAction: ExecuteShowFoodsPage,
            canExecuteFunc: CanExecuteShowFoodsPage);

        ShowUsersPageCommand = new RelayCommand(executeAction: ExecuteShowUsersPage,
           canExecuteFunc: CanExecuteShowUsersPage);

        ShowBookingsPageCommand = new RelayCommand(executeAction: ExecuteShowBookingsPage,
            canExecuteFunc: CanExecuteShowBookingsPage);

        ShowMailSubscribersPageCommand = new RelayCommand(executeAction: ExecuteShowMailSubscribersPage,
            canExecuteFunc: CanExecuteShowMailSubscribersPage);

        ShowContactMessagesPageCommand = new RelayCommand(executeAction: ExecuteShowContactMessagesPage,
            canExecuteFunc: CanExecuteShowContactMessagesPage);
    }

    #endregion
}