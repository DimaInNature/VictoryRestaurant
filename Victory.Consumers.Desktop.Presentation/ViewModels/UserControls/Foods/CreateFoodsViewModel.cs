namespace Victory.Consumers.Desktop.Presentation.ViewModels;

internal sealed class CreateFoodsViewModel : BaseCreateViewModel
{
    #region Members

    #region Properties

    public string Name
    {
        get => _name ?? string.Empty;
        set
        {
            int maxLenght = 25;

            Regex trimmer = new(@"\s\s+", options: RegexOptions.Compiled);

            if (value == string.Empty)
            {
                _name = null;

                OnPropertyChanged(nameof(Name));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                if (char.IsWhiteSpace(c: value.FirstOrDefault()))
                    value = value.TrimStart(trimChar: ' ');
            }

            value = trimmer.Replace(input: value, replacement: " ");

            _name = value;

            OnPropertyChanged(nameof(Name));
        }
    }

    public string Description
    {
        get => _description ?? string.Empty;
        set
        {
            int maxLenght = 50;

            Regex trimmer = new(@"\s\s+", options: RegexOptions.Compiled);

            if (value == string.Empty)
            {
                _description = null;

                OnPropertyChanged(nameof(Description));

                return;
            }

            if (value.Length > 0)
            {
                if (value.Length > maxLenght) return;

                if (char.IsWhiteSpace(c: value.FirstOrDefault()))
                    value = value.TrimStart(trimChar: ' ');
            }

            value = trimmer.Replace(input: value, replacement: " ");

            _description = value;

            OnPropertyChanged(nameof(Description));
        }
    }

    public double? CostInUSD
    {
        get => _costInUSD;
        set
        {
            int maxLenght = 99999;

            if (value > maxLenght) return;

            if (value > 0 || value is null)
            {
                _costInUSD = value;

                OnPropertyChanged(nameof(CostInUSD));
            }
        }
    }

    public List<FoodType> FoodTypes
    {
        get => _foodTypes ?? new();
        set
        {
            _foodTypes = value;

            OnPropertyChanged(nameof(FoodTypes));
        }
    }

    public FoodType? SelectedType
    {
        get => _selectedType;
        set
        {
            _selectedType = value;

            OnPropertyChanged(nameof(SelectedType));
        }
    }

    #endregion

    #region Private

    private string? _name;

    private string? _description;

    private double? _costInUSD;

    private FoodType? _selectedType;

    private List<FoodType> _foodTypes = new();

    private string? _imagePath;

    #endregion

    #region Commands

    public RelayCommand? ChoiceImageCommand { get; private set; }

    #endregion

    #region Dependencies

    private readonly IFoodService _foodService;

    private readonly IFoodTypeService _foodTypeService;

    private readonly ImageUploaderService _imageUploader;

    private readonly UserSessionService _userSessionService;

    #endregion

    #endregion

    public CreateFoodsViewModel(
        IFoodService foodService,
        ImageUploaderService imageUploader,
        IFoodTypeService foodTypeService,
        UserSessionService userSessionService)
    {
        (_foodService, _imageUploader, _foodTypeService, _userSessionService) =
            (foodService, imageUploader, foodTypeService, userSessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeFoodTypes());
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Name, Description, _imagePath ?? string.Empty) &&
        CostInUSD > 0 && SelectedType is not null;

    private bool CanExecuteChoiceImage(object obj) => true;

    protected override async void ExecuteCreate(object obj)
    {
        string? token = _userSessionService.JwtToken;

        if (string.IsNullOrWhiteSpace(_imagePath) || SelectedType is null ||
            string.IsNullOrWhiteSpace(value: token)) return;

        var foods = await _foodService.GetFoodListAsync();

        foods = foods.Where(food => food.Name == Name).ToList();

        if (foods.Count > 0)
        {
            MessageBox.Show(
                messageBoxText: "A food with this name already exists",
                caption: "Information",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Information);

            return;
        }

        string? imageURL = await _imageUploader.Upload(
            image: new CloudinaryImage(path: _imagePath),
            account: new Account(cloud: ApplicationConfiguration.ImageHostAuth.Cloud,
            apiKey: ApplicationConfiguration.ImageHostAuth.ApiKey,
            apiSecret: ApplicationConfiguration.ImageHostAuth.ApiSecret),
            subFolder: SelectedType.Name,
            name: Name);

        Food food = new()
        {
            Name = Name,
            Description = Description,
            CostInUSD = CostInUSD ?? 1,
            FoodTypeId = SelectedType.Id,
            CreatedDate = DateTime.UtcNow,
            ImagePath = imageURL ?? string.Empty
        };

        await _foodService.CreateAsync(entity: food, token);

        MessageBox.Show(
            messageBoxText: "The addition was successful",
            caption: "Success",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    private void ExecuteChoiceImage(object obj)
    {
        using var fileDialog = new winForms.OpenFileDialog()
        {
            Filter = "Image Files|*.jpg;*.jpeg;*.png;*.img;"
        };

        winForms.DialogResult result = fileDialog.ShowDialog();

        if (result is winForms.DialogResult.OK && string.IsNullOrWhiteSpace(fileDialog.FileName) is false)
            _imagePath = fileDialog.FileName;
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);

        ChoiceImageCommand = new RelayCommand(executeAction: ExecuteChoiceImage,
            canExecuteFunc: CanExecuteChoiceImage);
    }

    private void Clear()
    {
        Name = string.Empty;
        Description = string.Empty;
        CostInUSD = null;
        SelectedType = default;
        _imagePath = string.Empty;
    }

    private async Task InitializeFoodTypes() =>
        FoodTypes = await _foodTypeService.GetFoodTypeListAsync();

    #endregion
}