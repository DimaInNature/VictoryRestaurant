namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class ReadBookingsView : UserControl
{
    public ReadBookingsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IReadBookingsViewModel>();
    }
}