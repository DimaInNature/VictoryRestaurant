namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Foods;

public partial class UpdateFoodsView : UserControl
{
    private readonly UpdateFoodsViewModel? _viewModel = (System.Windows.Application.Current as App)?
       .ServiceProvider?.GetService<UpdateFoodsViewModel>();

    public UpdateFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}