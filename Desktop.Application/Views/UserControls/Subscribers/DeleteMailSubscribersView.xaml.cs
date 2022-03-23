namespace Desktop.Presentation.Views.UserControls.Subscribers;

sealed partial class DeleteMailSubscribersView : UserControl
{
    public DeleteMailSubscribersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IDeleteMailSubscribersViewModel>();
    }
}