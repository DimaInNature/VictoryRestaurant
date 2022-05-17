namespace Victory.Presentation.Desktop.Views.UserControls.Users;

sealed partial class UsersView : UserControl
{
    private readonly IUsersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<IUsersViewModel>();

    public UsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        SetFrame(source: new ReadUsersView());
    }

    private void ViewRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadUsersView());

    private void CreateRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateUsersView());

    private void UpdateRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new UpdateUsersView());

    private void DeleteRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteUsersView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        MenuFrame.Content = source;
    }
}