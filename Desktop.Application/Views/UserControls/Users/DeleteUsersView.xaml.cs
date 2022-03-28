namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class DeleteUsersView : UserControl
{
    private readonly IDeleteUsersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteUsersViewModel>();

    public DeleteUsersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}