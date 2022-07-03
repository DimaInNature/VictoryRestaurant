namespace Victory.Presentation.Desktop.Views;

sealed partial class MainView : Window
{
    private readonly MainViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<MainViewModel>();

    private readonly UserSessionService? _sessionService = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<UserSessionService>();

    public MainView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        ActiveUserNameTextBlock.Text = _sessionService?.ActiveUser?.Login;
    }

    private void Window_MouseLeftDown(object sender, MouseButtonEventArgs e) => DragMove();

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

    private void HomeButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, HomeMenuButton.IsChecked) = ("Victory - Home", true);

        SetBody(control: HomeBody);
    }

    private void ViewButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, ViewMenuButton.IsChecked) = ("Victory - View", true);

        SetFrame(source: new ViewMenuView());
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, CreateMenuButton.IsChecked) = ("Victory - Create", true);

        SetFrame(source: new CreateMenuView());
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        if (_sessionService?.ActiveUser?.UserRole?.Name is not "Admin")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights",
                caption: "Security system",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        (Title, UpdateMenuButton.IsChecked) = ("Victory - Update", true);

        SetFrame(source: new UpdateMenuView());
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, DeleteMenuButton.IsChecked) = ("Victory - Delete", true);

        SetFrame(source: new DeleteMenuView());
    }

    private void LogoutMenuButton_Click(object sender, RoutedEventArgs e)
    {
        _sessionService?.EndSession();

        new LoginView().Show();

        Close();
    }

    private void SmtpMailingButton_Click(object sender, RoutedEventArgs e)
    {
        if (_sessionService?.ActiveUser?.UserRole?.Name is not "Admin")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights",
                caption: "Security system",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        (Title, SMTPMailingMenuButton.IsChecked) = ("Victory - Mailing", true);

        SetFrame(source: new SendMailSubscribersView());
    }

    private void OpenWebButton_Click(object sender, RoutedEventArgs e)
    {
        string url = ApplicationConfiguration.Web.Url;

        try
        {
            Process.Start(url);
        }
        catch
        {
            url = url.Replace(oldValue: "&", newValue: "^&");

            Process.Start(startInfo: new ProcessStartInfo(fileName: url) { UseShellExecute = true });
        }
    }

    private void OpenImageCloud_Click(object sender, RoutedEventArgs e)
    {
        if (_sessionService?.ActiveUser?.UserRole?.Name is not "Admin")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights",
                caption: "Security system",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        string url = "https://cloudinary.com/console/";

        try
        {
            Process.Start(url);
        }
        catch
        {
            url = url.Replace(oldValue: "&", newValue: "^&");

            Process.Start(startInfo: new ProcessStartInfo(fileName: url) { UseShellExecute = true });
        }
    }

    private void OpenAPIButton_Click(object sender, RoutedEventArgs e)
    {
        if (_sessionService?.ActiveUser?.UserRole?.Name is not "Admin")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights",
                caption: "Security system",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        string url = $"{ApplicationConfiguration.ServerAPI.Url}/swagger/index.html";

        try
        {
            Process.Start(url);
        }
        catch
        {
            url = url.Replace(oldValue: "&", newValue: "^&");

            Process.Start(startInfo: new ProcessStartInfo(fileName: url) { UseShellExecute = true });
        }
    }

    private void MainMenuButton_Click(object sender, RoutedEventArgs e)
    {
        (Title, HomeMenuButton.IsChecked) = ("Victory - Menu", true);

        SetBody(control: MainMenuBody);
    }

    private void SMTPMailingMenuButton_Click(object sender, RoutedEventArgs e)
    {
        if (_sessionService?.ActiveUser?.UserRole?.Name is not "Admin")
        {
            MessageBox.Show(
                messageBoxText: "You don't have access rights",
                caption: "Security system",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error);

            return;
        }

        (Title, SMTPMailingMenuButton.IsChecked) = ("Victory - Mailing", true);

        SetFrame(source: new SendMailSubscribersView());
    }

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBodies();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void SetBody(Panel control)
    {
        CollapseFrame();

        CollapseBodies();

        control.Visibility = Visibility.Visible;
    }

    private void CollapseBodies() =>
        HomeBody.Visibility = MainMenuBody.Visibility = Visibility.Collapsed;

    private void CollapseFrame() =>
        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Collapsed, null);
}