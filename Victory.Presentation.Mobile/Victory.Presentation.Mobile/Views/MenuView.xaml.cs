namespace Victory.Presentation.Mobile.Views;

[XamarinXaml.XamlCompilation(XamarinXaml.XamlCompilationOptions.Compile)]
public partial class MenuView : ContentPage
{
    public MenuView()
    {
        InitializeComponent();

        BindingContext = App.GetViewModel<MenuViewModel>();
    }

    private void CarouselPositionChanged(object sender, PositionChangedEventArgs e)
    {
        var carousel = sender as CarouselView;
        var carouselItems = carousel?.VisibleViews;

        if (carouselItems?.Count > 0)
            foreach (var item in carouselItems)
            {
                Image img = item.FindByName<Image>(name: "MenuImg");

                ViewExtensions.CancelAnimations(view: img);

                Task.Run(async () => await img.RelRotateTo(
                    drotation: 360,
                    length: 5000,
                    easing: Easing.BounceOut));
            }
    }
}