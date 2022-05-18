namespace Victory.Presentation.Desktop.Views.UserControls.Subscribers;

public partial class SendMailSubscribersView : UserControl
{
    private readonly ISendMailSubscribersViewModel? _viewModel = (System.Windows.Application.Current as App)?
      .ServiceProvider?.GetService<ISendMailSubscribersViewModel>();

    public SendMailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}