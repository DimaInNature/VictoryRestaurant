namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class UpdateBookingsView : UserControl
{
    public UpdateBookingsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IUpdateBookingsViewModel>();
    }
}