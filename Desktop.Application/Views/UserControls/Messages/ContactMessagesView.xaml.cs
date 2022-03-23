namespace Desktop.Presentation.Views.UserControls.Messages;

sealed partial class ContactMessagesView : UserControl
{
    public ContactMessagesView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IContactMessagesViewModel>();
    }
}