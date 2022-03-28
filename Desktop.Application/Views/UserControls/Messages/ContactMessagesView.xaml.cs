namespace Desktop.Presentation.Views.UserControls.Messages;

sealed partial class ContactMessagesView : UserControl
{
    private readonly IContactMessagesViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IContactMessagesViewModel>();

    public ContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}