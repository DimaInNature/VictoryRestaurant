using Desktop.Presentation.Views.UserControls;

namespace Desktop.Presentation.ViewModels;

public class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        InitializeCommands();
    }

    #region Properties

    #region View

    #region Frame

    public Visibility FrameVisibility
    {
        get => _frameVisibility;
        set
        {
            _frameVisibility = value;
            OnPropertyChanged(nameof(FrameVisibility));
        }
    }

    private Visibility _frameVisibility;

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

    private object _frameSource;

    #endregion

    public Visibility MenuIsVisible
    {
        get => _menuIsVisible;
        set
        {
            _menuIsVisible = value;
            OnPropertyChanged(nameof(MenuIsVisible));
        }
    }

    private Visibility _menuIsVisible;

    #endregion

    #endregion

    #region Commands

    public ICommand ShowMenuPageCommand { get; private set; }

    public ICommand ShowFoodPageCommand { get; private set; }

    public ICommand ShowBlogPageCommand { get; private set; }

    public ICommand ShowOrderPageCommand { get; private set; }

    public ICommand ShowSettingsPageCommand { get; private set; }

    public ICommand LogoutCommand { get; private set; }

    public ICommand CloseApplicationCommand { get; private set; }

    #endregion

    #region Command Logic

    #region Execute

    private void ExecuteShowFoodPage(object obj)
    {
        FrameSource = new FoodView();
    }

    private void ExecuteShowMenuPage(object obj)
    {
        FrameSource = null;
    }

    private void ExecuteShowOrderPage(object obj)
    {

    }

    private void ExecuteShowBlogPage(object obj)
    {

    }

    private void ExecuteShowSettingsPage(object obj)
    {

    }

    private static void ExecuteCloseApplication(object obj) =>
      Application.Current.Shutdown();

    private void ExecuteLogout(object obj)
    {
        new LoginView().Show();

        (obj as MainView)?.Close();
    }

    #endregion

    #region CanExecute

    private bool CanExecuteShowMenuPage(object obj) =>
        !(FrameSource is null && MenuIsVisible is Visibility.Visible);

    private bool CanExecuteShowFoodPage(object obj) =>
        (FrameSource is not FoodView);

    private bool CanExecuteShowOrderPage(object obj) =>
        true;

    private bool CanExecuteShowBlogPage(object obj) =>
       true;

    private bool CanExecuteShowSettingsPage(object obj) =>
        true;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowMenuPageCommand = new RelayCommand(executeAction: ExecuteShowMenuPage,
            canExecuteFunc: CanExecuteShowMenuPage);

        ShowFoodPageCommand = new RelayCommand(executeAction: ExecuteShowFoodPage,
            canExecuteFunc: CanExecuteShowFoodPage);

        ShowOrderPageCommand = new RelayCommand(executeAction: ExecuteShowOrderPage,
            canExecuteFunc: CanExecuteShowOrderPage);

        ShowBlogPageCommand = new RelayCommand(executeAction: ExecuteShowBlogPage,
            canExecuteFunc: CanExecuteShowBlogPage);

        ShowSettingsPageCommand = new RelayCommand(executeAction: ExecuteShowSettingsPage,
            canExecuteFunc: CanExecuteShowSettingsPage);

        LogoutCommand = new RelayCommand(executeAction: ExecuteLogout);

        CloseApplicationCommand = new RelayCommand(executeAction: ExecuteCloseApplication);
    }

    #endregion
}
