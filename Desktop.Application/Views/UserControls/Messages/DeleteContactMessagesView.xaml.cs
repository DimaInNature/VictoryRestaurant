namespace Desktop.Presentation.Views.UserControls.Messages;

public partial class DeleteContactMessagesView : UserControl
{
    private readonly IDeleteContactMessagesViewModel? _viewModel = (Application.Current as App)?
       .ServiceProvider?.GetService<IDeleteContactMessagesViewModel>();

    public DeleteContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}