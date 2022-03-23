namespace Desktop.Presentation.Views.UserControls.Foods;

sealed partial class ReadFoodsView : UserControl
{
    public ReadFoodsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IReadFoodsViewModel>();
    }
}