namespace Desktop.Presentation.Views.UserControls.Messages;

sealed partial class ReadContactMessagesView : UserControl
{
    public ReadContactMessagesView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
            .ServiceProvider?.GetService<IReadContactMessagesViewModel>();
    }
}