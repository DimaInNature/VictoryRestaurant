namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class UpdateUsersView : UserControl
{
    public UpdateUsersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IUpdateUsersViewModel>();
    }
}