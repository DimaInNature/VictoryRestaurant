namespace Desktop.Presentation.Views.UserControls.Foods;

sealed partial class CreateFoodsView : UserControl
{
    public CreateFoodsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<ICreateFoodsViewModel>();
    }
}