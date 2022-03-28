namespace Desktop.Presentation.Views.UserControls.Foods;

sealed partial class ReadFoodsView : UserControl
{
    private readonly IReadFoodsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<IReadFoodsViewModel>();

    public ReadFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}