namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Menus;

public partial class CreateMenuView : UserControl
{
    private readonly UserSessionService? _sessionService = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<UserSessionService>();

    public CreateMenuView() => InitializeComponent();

    private void FoodButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateFoodsView());

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

        SetFrame(source: new CreateUsersView());
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

        SetFrame(source: new CreateTablesView());
    }

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        CollapseBody();

        (MenuFrame.Visibility, MenuFrame.Content) = (Visibility.Visible, source);
    }

    private void CollapseBody() => MenuBody.Visibility = Visibility.Collapsed;
}