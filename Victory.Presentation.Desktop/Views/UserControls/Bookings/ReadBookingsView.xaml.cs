namespace Victory.Presentation.Desktop.Views.UserControls.Bookings;

sealed partial class ReadBookingsView : UserControl
{
    private readonly IReadBookingsViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<IReadBookingsViewModel>();

    public ReadBookingsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}