namespace Victory.Presentation.Desktop.Views.UserControls.Messages;

sealed partial class ContactMessagesView : UserControl
{
    private readonly IContactMessagesViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<IContactMessagesViewModel>();

    public ContactMessagesView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        SetFrame(source: new ReadContactMessagesView());
    }

    private void ViewRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadContactMessagesView());

    private void DeleteRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteContactMessagesView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        MenuFrame.Content = source;
    }
}