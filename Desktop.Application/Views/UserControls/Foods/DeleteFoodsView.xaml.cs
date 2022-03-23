namespace Desktop.Presentation.Views.UserControls.Foods;

public partial class DeleteFoodsView : UserControl
{
    public DeleteFoodsView()
    {
        InitializeComponent();

        DataContext = (Application.Current as App)?
               .ServiceProvider?.GetService<IDeleteFoodsViewModel>();
    }
}