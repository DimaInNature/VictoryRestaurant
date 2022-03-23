namespace Desktop.Presentation.Views.UserControls.Foods;

public partial class UpdateFoodsView : UserControl
{
    public UpdateFoodsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IUpdateFoodsViewModel>();
    }
}