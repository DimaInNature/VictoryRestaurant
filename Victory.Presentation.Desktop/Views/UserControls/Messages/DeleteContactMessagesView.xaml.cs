namespace Victory.Presentation.Desktop.Views.UserControls.Messages;

public partial class DeleteContactMessagesView : UserControl
{
    private readonly IDeleteContactMessagesViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<IDeleteContactMessagesViewModel>();

    public DeleteContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}