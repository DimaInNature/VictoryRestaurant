namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class ReadBookingsView : UserControl
{
    private readonly ReadBookingsViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<ReadBookingsViewModel>();

    public ReadBookingsView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}