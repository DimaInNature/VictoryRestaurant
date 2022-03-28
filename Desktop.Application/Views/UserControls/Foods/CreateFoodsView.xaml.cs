namespace Desktop.Presentation.Views.UserControls.Foods;

sealed partial class CreateFoodsView : UserControl
{
    private readonly ICreateFoodsViewModel? _viewModel = (Application.Current as App)?
        .ServiceProvider?.GetService<ICreateFoodsViewModel>();

    public CreateFoodsView()
    {
        InitializeComponent();

        if (_viewModel is null)
            throw new NullReferenceException("ViewModel is null");

        DataContext = _viewModel;

        string[] typeNames = Enum.GetNames(typeof(FoodType));
        typeNames[0] = "Выберите тип";

        (TypeListComboBox.ItemsSource, TypeListComboBox.SelectedIndex) = (typeNames, 0);
    }
}