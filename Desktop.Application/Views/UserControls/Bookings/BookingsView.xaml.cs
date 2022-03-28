namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class BookingsView : UserControl
{
    private readonly IBookingsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IBookingsViewModel>();

    public BookingsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("BookingsViewModel is null");

        DataContext = _viewModel;
    }
}