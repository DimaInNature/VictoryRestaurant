namespace Desktop.Presentation.Views.UserControls.Subscribers;

public partial class MailSubscribersView : UserControl
{
    public MailSubscribersView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IMailSubscribersViewModel>();
    }
}