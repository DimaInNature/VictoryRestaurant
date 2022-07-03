namespace Victory.Presentation.Desktop.Views;

sealed partial class LoginView : Window
{
    private readonly LoginViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<LoginViewModel>();

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

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        _viewModel.IsConnectionStopped = false;

        (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (false, false);

        Task.Run(action: () =>
        {
            while (_viewModel.IsConnectionStopped is false) { }

            Dispatcher.Invoke(callback: () => (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (true, true));
        });
    }

    private void MaximazedButton_Click(object sender, RoutedEventArgs e) =>
       WindowState = WindowState switch
       {
           WindowState.Normal => WindowState.Maximized,
           _ => WindowState.Normal,
       };

    private void RollUpButton_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void ExitButton_Click(object sender, RoutedEventArgs e) =>
        System.Windows.Application.Current.Shutdown();

    private void EnterPasswordPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        (_viewModel.Password, _viewModel.SecurePassword) = (EnterPasswordPasswordBox.Password, EnterPasswordPasswordBox.SecurePassword);
    }

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) => System.Windows.Application.Current.Shutdown();

    private void EnterButton_Click(object sender, RoutedEventArgs e)
    {
        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        _viewModel.IsConnectionStopped = false;

        (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (false, false);

        Task.Run(action: () =>
        {
            while (_viewModel.IsConnectionStopped is false) { }

            Dispatcher.Invoke(callback: () => (EnterButton.IsEnabled, RegisterButton.IsEnabled) = (true, true));
        });
    }
}