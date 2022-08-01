namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Users;

sealed partial class UpdateUsersView : UserControl
{
    private readonly UpdateUsersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<UpdateUsersViewModel>();

    public UpdateUsersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}