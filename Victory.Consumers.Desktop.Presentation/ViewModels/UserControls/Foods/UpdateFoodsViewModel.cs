namespace Victory.Consumers.Desktop.Presentation.ViewModels;

internal sealed class UpdateFoodsViewModel : BaseUpdateViewModel<Food, FoodType>
{
    private readonly IFoodService _foodService;

    private readonly IFoodTypeService _foodTypeService;

    private readonly UserSessionService _userSessionService;

    public UpdateFoodsViewModel(
        IFoodService foodService,
        IFoodTypeService foodTypeService,
        UserSessionService userSessionService)
    {
        (_foodService, _foodTypeService, _userSessionService) = (foodService, foodTypeService, userSessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedGeneralValue is not null && SelectedAggregatedValue is not null && SelectedGeneralValue.CostInUSD > 0 &&
        StringHelper.StrIsNotNullOrWhiteSpace(SelectedGeneralValue.Name, SelectedGeneralValue.Description);

    protected override async void ExecuteUpdateCommand(object obj)
    {
        string? token = _userSessionService.JwtToken;

        if (SelectedGeneralValue is null || SelectedAggregatedValue is null ||
            string.IsNullOrWhiteSpace(value: token)) return;

        SelectedGeneralValue.FoodTypeId = SelectedAggregatedValue.Id;

        await _foodService.UpdateAsync(entity: SelectedGeneralValue, token);

        MessageBox.Show(
           messageBoxText: "The change was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    protected override void SelectGeneralValue()
    {
        if (SelectedGeneralValue is not null)
        {
            SelectedAggregatedValue = SelectedGeneralValue.FoodType;

            SelectedAggredatedValueIndex = AggregatedDataList.FindIndex(match: x => x.Id == SelectedAggregatedValue?.Id);
        }
    }

    protected override async void Find(string filter)
    {
        var foods = await _foodService.GetFoodListAsync();

        filter = filter.ToLower();

        GeneralDataList = foods.Where(
            predicate: food =>
            food.Name.ToLower().Contains(value: filter) |
            food.Description.ToLower().Contains(value: filter))
            .ToList();
    }

    protected override async Task UpdateData() => await InitializeData();

    private void InitializeCommands()
    {
        UpdateCommand = new RelayCommand(executeAction: ExecuteUpdateCommand,
            canExecuteFunc: CanExecuteUpdateCommand);
    }

    private async Task InitializeData()
    {
        GeneralDataList = await _foodService.GetFoodListAsync();

        AggregatedDataList = await _foodTypeService.GetFoodTypeListAsync();
    }

    #endregion
}