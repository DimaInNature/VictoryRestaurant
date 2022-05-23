namespace Victory.Presentation.Mobile.Views;

[XamarinXaml.XamlCompilation(XamarinXaml.XamlCompilationOptions.Compile)]
public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();

        BindingContext = App.GetViewModel<MainViewModel>();
    }

    private async void OpenAnimation()
    {
        await swipeContent.ScaleYTo(scale: 0.9, length: 200, easing: Easing.SinOut);

        pancake.CornerRadius = 10;

        await swipeContent.RotateTo(rotation: -5, length: 200, easing: Easing.SinOut);
    }

    private async void CloseAnimation()
    {
        await swipeContent.ScaleYTo(scale: 1, length: 200, easing: Easing.SinOut);

        pancake.CornerRadius = 0;

        await swipeContent.RotateTo(rotation: 0, length: 200, easing: Easing.SinOut);
    }

    private void OpenSwipe(object sender, EventArgs e)
    {
        MainSwipeView.Open(openSwipeItem: OpenSwipeItem.LeftItems);

        OpenAnimation();
    }

    private void CloseSwipe(object sender, EventArgs e)
    {
        MainSwipeView.Close();

        CloseAnimation();
    }

    private void SwipeStarted(object sender, SwipeStartedEventArgs e) => OpenAnimation();

    private void SwipeEnded(object sender, SwipeEndedEventArgs e)
    {
        if (!e.IsOpen) CloseAnimation();
    }
}