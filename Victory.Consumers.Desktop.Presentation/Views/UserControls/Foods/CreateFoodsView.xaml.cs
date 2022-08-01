namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Foods;

sealed partial class CreateFoodsView : UserControl
{
    private readonly CreateFoodsViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<CreateFoodsViewModel>();

    public CreateFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}