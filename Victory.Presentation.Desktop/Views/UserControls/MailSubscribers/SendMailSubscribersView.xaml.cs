namespace Victory.Presentation.Desktop.Views.UserControls.MailSubscribers;

public partial class SendMailSubscribersView : UserControl
{
    private readonly SendMailSubscribersViewModel? _viewModel = (System.Windows.Application.Current as App)?
      .ServiceProvider?.GetService<SendMailSubscribersViewModel>();

    public SendMailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}