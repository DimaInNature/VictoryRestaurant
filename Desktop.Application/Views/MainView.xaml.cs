namespace Desktop.Presentation.Views;

sealed partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
                .ServiceProvider?.GetService<IMainViewModel>();
    }

    public MainView(User activeUser) : this()
    {
        var vm = DataContext as MainViewModel ?? new MainViewModel();
        vm.ActiveUser = activeUser;
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
        new LoginView().Show();

        Close();
    }

    private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();
}