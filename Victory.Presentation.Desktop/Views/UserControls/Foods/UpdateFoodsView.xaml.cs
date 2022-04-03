namespace Victory.Presentation.Desktop.Views.UserControls.Foods;

public partial class UpdateFoodsView : UserControl
{
    private readonly IUpdateFoodsViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<IUpdateFoodsViewModel>();

    public UpdateFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}