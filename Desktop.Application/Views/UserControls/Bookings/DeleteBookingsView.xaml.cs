namespace Desktop.Presentation.Views.UserControls.Bookings;

sealed partial class DeleteBookingsView : UserControl
{
    public DeleteBookingsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IDeleteBookingsViewModel>();
    }
}