namespace Desktop.Presentation.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
        DataContext = (Application.Current as App)?
                .ServiceProvider?.GetService<MainViewModel>();
    }

    public MainView(User activeUser) : this()
    {
        var vm = DataContext as MainViewModel ?? new MainViewModel();
        vm.ActiveUser = activeUser;
    }

    private void WindowDragMove(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
}