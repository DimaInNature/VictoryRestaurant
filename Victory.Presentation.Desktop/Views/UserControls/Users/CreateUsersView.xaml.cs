namespace Victory.Presentation.Desktop.Views.UserControls.Users;

sealed partial class CreateUsersView : UserControl
{
    private readonly CreateUsersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<CreateUsersViewModel>();

    public CreateUsersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}