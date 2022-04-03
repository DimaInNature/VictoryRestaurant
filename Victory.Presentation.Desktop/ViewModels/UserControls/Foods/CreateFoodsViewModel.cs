namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class CreateFoodsViewModel
    : BaseCreateViewModel, ICreateFoodsViewModel
{
    #region Members

    #region Properties

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Description
    {
        get => _description ?? string.Empty;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    public double? CostInUSD
    {
        get => _costInUSD;
        set
        {
            if (value > 0 || value is null)
            {
                _costInUSD = value;
                OnPropertyChanged(nameof(CostInUSD));
            }
        }
    }

    public FoodType Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    #endregion

    #region Private

    private string? _name;

    private string? _description;

    private double? _costInUSD;

    private FoodType _type;

    #endregion

    #region Dependencies

    private readonly IFoodFacadeService _foodService;

    #endregion

    #endregion

    public CreateFoodsViewModel(IFoodFacadeService foodService)
    {
        _foodService = foodService;

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Name, Description) && CostInUSD > 0 &&
        Enum.IsDefined(typeof(FoodType), Type) && Type is not FoodType.None;

    protected override async void ExecuteCreate(object obj)
    {
        Food food = new()
        {
            Name = Name,
            Description = Description,
            CostInUSD = CostInUSD ?? 1,
            Type = Type,
            CreatedDate = DateTime.UtcNow,
            ImagePath = "https://localhost:7059/img/foods/breakfast_item.jpg"
        };

        await _foodService.CreateAsync(food);

        MessageBox.Show(
            messageBoxText: "Добавление произошло успешно",
            caption: "Успех",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);
    }

    private void Clear()
    {
        Name = string.Empty;
        Description = string.Empty;
        CostInUSD = null;
        Type = default;
    }

    #endregion
}