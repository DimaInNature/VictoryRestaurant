namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class CreateBookingsView : UserControl
{
    public CreateBookingsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<ICreateBookingsViewModel>();
    }
}