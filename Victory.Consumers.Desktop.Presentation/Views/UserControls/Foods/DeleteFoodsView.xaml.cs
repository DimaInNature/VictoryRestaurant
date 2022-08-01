namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Foods;

public partial class DeleteFoodsView : UserControl
{
    private readonly DeleteFoodsViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<DeleteFoodsViewModel>();

    public DeleteFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}