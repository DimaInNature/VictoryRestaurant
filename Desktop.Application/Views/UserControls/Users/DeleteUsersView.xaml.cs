namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class DeleteUsersView : UserControl
{
    public DeleteUsersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IDeleteUsersViewModel>();
    }
}