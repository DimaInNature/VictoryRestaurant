namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.ContactMessages;

public partial class DeleteContactMessagesView : UserControl
{
    private readonly DeleteContactMessagesViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<DeleteContactMessagesViewModel>();

    public DeleteContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}