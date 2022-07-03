namespace Victory.Presentation.Desktop.Views.UserControls.Menus;

public partial class UpdateMenuView : UserControl
{
    private readonly UserSessionService? _sessionService = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<UserSessionService>();

    public UpdateMenuView() => InitializeComponent();

    private void FoodButton_Click(object sender, RoutedEventArgs e)
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

        SetFrame(source: new UpdateFoodsView());
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

        SetFrame(source: new UpdateUsersView());
    }

    private void TableButton_Click(object sender, RoutedEventArgs e)
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

        SetFrame(source: new UpdateTablesView());
    }

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}