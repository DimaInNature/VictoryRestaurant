namespace Victory.Presentation.Desktop.Views.UserControls.MailSubscribers;

sealed partial class ReadMailSubscribersView : UserControl
{
    private readonly ReadMailSubscribersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<ReadMailSubscribersViewModel>();

    public ReadMailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}