namespace Desktop.Presentation.Views.UserControls.Users;

sealed partial class ReadUsersView : UserControl
{
    public ReadUsersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IReadUsersViewModel>();
    }
}