namespace Victory.Presentation.Desktop.Views.UserControls.Subscribers;

public partial class MailSubscribersView : UserControl
{
    private readonly IMailSubscribersViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<IMailSubscribersViewModel>();

    public MailSubscribersView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        SetFrame(source: new ReadMailSubscribersView());
    }

    private void ViewRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadMailSubscribersView());

    private void DeleteRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteMailSubscribersView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        MenuFrame.Content = source;
    }
}