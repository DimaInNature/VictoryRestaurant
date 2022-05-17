namespace Victory.Presentation.Desktop.Views.UserControls.Bookings;

sealed partial class BookingsView : UserControl
{
    private readonly IBookingsViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<IBookingsViewModel>();

    public BookingsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("BookingsViewModel is null");

        DataContext = _viewModel;

        SetFrame(source: new ReadBookingsView());
    }

    private void ViewRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadBookingsView());

    private void DeleteRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteBookingsView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        MenuFrame.Content = source;
    }
}