namespace Victory.Presentation.Desktop.Views.UserControls.Subscribers;

sealed partial class DeleteMailSubscribersView : UserControl
{
    private readonly IDeleteMailSubscribersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<IDeleteMailSubscribersViewModel>();

    public DeleteMailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}