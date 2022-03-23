namespace Desktop.Presentation.Views.UserControls.Subscribers;

sealed partial class UpdateMailSubscribersView : UserControl
{
    public UpdateMailSubscribersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IUpdateMailSubscribersViewModel>();
    }
}