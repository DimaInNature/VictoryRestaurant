namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class UpdateUsersView : UserControl
{
    private readonly IUpdateUsersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IUpdateUsersViewModel>();

    public UpdateUsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}