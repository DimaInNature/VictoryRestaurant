namespace Victory.Presentation.Desktop.Views.UserControls.Users;

sealed partial class ReadUsersView : UserControl
{
    private readonly ReadUsersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<ReadUsersViewModel>();

    public ReadUsersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}