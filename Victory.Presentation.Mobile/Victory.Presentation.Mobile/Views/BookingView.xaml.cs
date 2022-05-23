namespace Victory.Presentation.Mobile.Views;

[XamarinXaml.XamlCompilation(XamarinXaml.XamlCompilationOptions.Compile)]
public partial class BookingView : ContentPage
{
    public BookingView()
    {
        InitializeComponent();

        BindingContext = App.GetViewModel<BookingViewModel>(); ;

        BookingDayPicker.ItemsSource = new List<string>()
        {
            "Понедельник","Вторник","Среда","Четверг","Пятница","Суббота","Воскресенье"
        };

        BookingTimePicker.ItemsSource = new List<string>()
        {
            "10:00","12:00","14:00","16:00","18:00","20:00","22:00"
        };

        BookingPersonCountPicker.ItemsSource = new List<string>()
        {
            "1 человек", "2 человека", "3 человека", "4 человека", "5 человек", "6 человек"
        };
    }
}