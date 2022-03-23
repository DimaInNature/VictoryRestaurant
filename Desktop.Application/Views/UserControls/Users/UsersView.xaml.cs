namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class UsersView : UserControl
{
    public UsersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IUsersViewModel>();
    }
}