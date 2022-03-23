namespace Desktop.Presentation.Views;

sealed partial class LoginView : Window
{
    private LoginViewModel ViewModel => (LoginViewModel)DataContext;

    public LoginView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<ILoginViewModel>();
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void EnterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e) =>
        (ViewModel.Password, ViewModel.SecurePassword) =
        (EnterPasswordPasswordBox.Password, EnterPasswordPasswordBox.SecurePassword);

    private void RegisterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e) =>
        (ViewModel.RegisterPassword, ViewModel.SecureRegisterPassword) =
        (RegisterPasswordPasswordBox.Password, RegisterPasswordPasswordBox.SecurePassword);

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();
}