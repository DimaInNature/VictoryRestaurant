namespace Victory.Presentation.Desktop.Views.UserControls.Tables;

public partial class DeleteTablesView : UserControl
{
    private readonly DeleteTablesViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<DeleteTablesViewModel>();

    public DeleteTablesView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}