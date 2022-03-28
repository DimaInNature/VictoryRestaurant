namespace Desktop.Presentation.Views;

sealed partial class MainView : Window
{
    private readonly IMainViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IMainViewModel>();

    private readonly UserSessionService? _sessionService = (Application.Current as App)?
        .ServiceProvider?.GetService<UserSessionService>();

    public MainView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        if (_sessionService?.ActiveUser?.Role is not UserRole.Admin)
        {
            UsersMenuRadioButton.Visibility = Visibility.Collapsed;
            UsersButton.Visibility = Visibility.Collapsed;
        }
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void FoodsButton_Click(object sender, RoutedEventArgs e) =>
        (FoodsMenuRadioButton.IsChecked, Title) = (true, "Victory - Меню");

    private void UsersButton_Click(object sender, RoutedEventArgs e) =>
        (UsersMenuRadioButton.IsChecked, Title) = (true, "Victory - Пользователи");

    private void BookingsButton_Click(object sender, RoutedEventArgs e) =>
        (BookingsMenuRadioButton.IsChecked, Title) = (true, "Victory - Заказы");

    private void MailSubscribersButton_Click(object sender, RoutedEventArgs e) =>
        (MailSubscribersMenuRadioButton.IsChecked, Title) = (true, "Victory - Подписчики");

    private void ContactMessagesButton_Click(object sender, RoutedEventArgs e) =>
        (ContactMessagesMenuRadioButton.IsChecked, Title) = (true, "Victory - Сообщения");

    private void HomeMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Victory - Главная";

    private void FoodsMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Victory - Меню";

    private void UsersMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Victory - Пользователи";

    private void BookingsMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Victory - Заказы";

    private void MailSubscribersMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Victory - Подписчики";

    private void ContactMessagesMenuRadioButton_Click(object sender, RoutedEventArgs e) =>
        Title = "Victory - Сообщения";

    private void LogoutMenuButton_Click(object sender, RoutedEventArgs e)
    {
        _sessionService?.EndSession();

        new LoginView().Show();

        Close();
    }

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();
}