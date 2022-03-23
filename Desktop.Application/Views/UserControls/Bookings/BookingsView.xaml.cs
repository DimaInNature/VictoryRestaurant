namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class BookingsView : UserControl
{
    public BookingsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IBookingsViewModel>();
    }
}