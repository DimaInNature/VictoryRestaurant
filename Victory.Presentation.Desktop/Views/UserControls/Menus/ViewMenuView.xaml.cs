namespace Victory.Presentation.Desktop.Views.UserControls.Menus;

public partial class ViewMenuView : UserControl
{
    private readonly UserSessionService? _sessionService = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<UserSessionService>();

    public ViewMenuView() => InitializeComponent();

    private void BookingButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadBookingsView());

    private void FoodButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadFoodsView());

    private void ContactMessageButton_Click(object sender, RoutedEventArgs e)
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

        SetFrame(source: new ReadContactMessagesView());
    }

    private void MailSubscriberButton_Click(object sender, RoutedEventArgs e)
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

        SetFrame(source: new ReadMailSubscribersView());
    }

    private void UserButton_Click(object sender, RoutedEventArgs e)
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

        SetFrame(source: new ReadUsersView());
    }

    private void TableButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadTablesView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}