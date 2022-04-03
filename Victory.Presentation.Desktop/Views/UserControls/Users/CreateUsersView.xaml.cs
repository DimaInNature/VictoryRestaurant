namespace Victory.Presentation.Desktop.Views.UserControls.Users;

sealed partial class CreateUsersView : UserControl
{
    private readonly ICreateUsersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<ICreateUsersViewModel>();

    public CreateUsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        string[] roleNames = Enum.GetNames(typeof(UserRole));
        roleNames[0] = "Выберите роль";

        (RoleListComboBox.ItemsSource, RoleListComboBox.SelectedIndex) = (roleNames, 0);
    }
}