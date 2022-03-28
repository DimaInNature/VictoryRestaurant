namespace Desktop.Presentation.Views.UserControls.Foods;

sealed partial class FoodsView : UserControl
{
    private readonly IFoodsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IFoodsViewModel>();

    public FoodsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}