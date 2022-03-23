namespace Desktop.Presentation.Views.UserControls.Messages;

public partial class DeleteContactMessagesView : UserControl
{
    public DeleteContactMessagesView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IDeleteContactMessagesViewModel>();
    }
}