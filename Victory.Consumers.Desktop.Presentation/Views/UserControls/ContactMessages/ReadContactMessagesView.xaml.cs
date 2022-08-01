namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.ContactMessages;

sealed partial class ReadContactMessagesView : UserControl
{
    private readonly ReadContactMessagesViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<ReadContactMessagesViewModel>();

    public ReadContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}