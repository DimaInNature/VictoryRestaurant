namespace Victory.Presentation.Desktop.Views.UserControls.Users;

sealed partial class DeleteUsersView : UserControl
{
    private readonly DeleteUsersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<DeleteUsersViewModel>();

    public DeleteUsersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}