namespace Victory.Presentation.Desktop.Views;

sealed partial class LoginView : Window
{
    private readonly ILoginViewModel? _viewModel = (System.Windows.Application.Current as App)?
               .ServiceProvider?.GetService<ILoginViewModel>();

    public LoginView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }

    private void EnterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        _viewModel.Password = EnterPasswordPasswordBox.Password;
        _viewModel.SecurePassword = EnterPasswordPasswordBox.SecurePassword;
    }


    private void RegisterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        _viewModel.RegisterPassword = RegisterPasswordPasswordBox.Password;
        _viewModel.SecureRegisterPassword = RegisterPasswordPasswordBox.SecurePassword;
    }

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) =>
        System.Windows.Application.Current.Shutdown();
}