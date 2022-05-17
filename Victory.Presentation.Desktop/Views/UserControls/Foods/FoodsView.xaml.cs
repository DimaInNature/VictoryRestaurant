namespace Victory.Presentation.Desktop.Views.UserControls.Foods;

sealed partial class FoodsView : UserControl
{
    private readonly IFoodsViewModel? _viewModel = (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<IFoodsViewModel>();

    public FoodsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        SetFrame(source: new ReadFoodsView());
    }

    private void ViewRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new ReadFoodsView());

    private void CreateRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new CreateFoodsView());

    private void UpdateRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new UpdateFoodsView());

    private void DeleteRadioButton_Click(object sender, RoutedEventArgs e) =>
        SetFrame(source: new DeleteFoodsView());

    private void SetFrame(ContentControl source)
    {
        if (source is null) throw new NullReferenceException(nameof(source));

        MenuFrame.Content = source;
    }
}