namespace Desktop.Presentation.Views.UserControls.Foods;

sealed partial class FoodsView : UserControl
{
    public FoodsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IFoodsViewModel>();
    }
}