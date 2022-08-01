namespace Victory.Consumers.Desktop.Presentation.Views.UserControls.Tables;

public partial class CreateTablesView : UserControl
{
    private readonly CreateTablesViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<CreateTablesViewModel>();

    public CreateTablesView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}