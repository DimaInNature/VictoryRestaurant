namespace Victory.Presentation.Desktop.Views.UserControls.Tables;

public partial class UpdateTablesView : UserControl
{
    private readonly UpdateTablesViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<UpdateTablesViewModel>();

    public UpdateTablesView()
    {
        InitializeComponent();

        if (_viewModel is null) throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;
    }
}