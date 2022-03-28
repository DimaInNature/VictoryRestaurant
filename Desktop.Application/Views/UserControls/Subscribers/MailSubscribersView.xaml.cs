namespace Desktop.Presentation.Views.UserControls.Subscribers;

public partial class MailSubscribersView : UserControl
{
    private readonly IMailSubscribersViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IMailSubscribersViewModel>();

    public MailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}