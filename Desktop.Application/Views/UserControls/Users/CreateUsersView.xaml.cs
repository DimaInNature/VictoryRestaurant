namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class CreateUsersView : UserControl
{
    public CreateUsersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<ICreateUsersViewModel>();
    }
}