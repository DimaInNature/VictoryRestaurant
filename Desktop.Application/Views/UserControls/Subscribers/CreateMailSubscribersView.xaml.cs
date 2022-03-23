namespace Desktop.Presentation.Views.UserControls.Subscribers;

sealed partial class CreateMailSubscribersView : UserControl
{
    public CreateMailSubscribersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<ICreateMailSubscribersViewModel>();
    }
}