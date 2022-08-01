namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class DeleteBookingsView : UserControl
{
    private readonly DeleteBookingsViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<DeleteBookingsViewModel>();

    public DeleteBookingsView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}