namespace Desktop.Presentation.Views.UserControls.Subscribers;

sealed partial class ReadMailSubscribersView : UserControl
{
    public ReadMailSubscribersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IReadMailSubscribersViewModel>();
    }
}