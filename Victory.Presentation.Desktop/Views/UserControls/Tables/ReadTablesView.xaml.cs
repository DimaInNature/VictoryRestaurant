namespace Victory.Presentation.Desktop.Views.UserControls.Tables;

sealed partial class ReadTablesView : UserControl
{
    private readonly ReadTablesViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<ReadTablesViewModel>();

    public ReadTablesView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}