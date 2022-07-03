﻿namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class UpdateFoodsViewModel : BaseUpdateViewModel<Food, FoodType>
{
    private readonly IFoodFacadeService _foodService;

    private readonly IFoodTypeFacadeService _foodTypeService;

    public UpdateFoodsViewModel(IFoodFacadeService foodService, IFoodTypeFacadeService foodTypeService)
    {
        (_foodService, _foodTypeService) = (foodService, foodTypeService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedGeneralValue is not null && SelectedAggregatedValue is not null && SelectedGeneralValue.CostInUSD > 0 &&
        StringHelper.StrIsNotNullOrWhiteSpace(SelectedGeneralValue.Name, SelectedGeneralValue.Description);

    protected override async void ExecuteUpdateCommand(object obj)
    {
        if (SelectedGeneralValue is null || SelectedAggregatedValue is null) return;

        SelectedGeneralValue.FoodTypeId = SelectedAggregatedValue.Id;

        await _foodService.UpdateAsync(SelectedGeneralValue);

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