namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class UpdateFoodsViewModel
    : BaseUpdateViewModel<Food>, IUpdateFoodsViewModel
{
    public string[] FoodTypes => Enum.GetNames(typeof(FoodType));

    private readonly IFoodFacadeService _foodService;

    public UpdateFoodsViewModel(IFoodFacadeService foodService)
    {
        _foodService = foodService;

        InitializeCommands();

        Task.Run(function: () => AutoUpdateData(
            secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
            isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Command Logic

    protected override bool CanExecuteUpdateCommand(object obj) =>
        SelectedItem is not null && SelectedItem.CostInUSD > 0 &&
        StringHelper.StrIsNotNullOrWhiteSpace(SelectedItem.Name, SelectedItem.Description);

    protected override async void ExecuteUpdateCommand(object obj)
    {
        if (SelectedItem is null || SelectedIndex is null) return;

        SelectedItem.Type = (FoodType)SelectedIndex;

        await _foodService.UpdateAsync(SelectedItem);

        MessageBox.Show(
           messageBoxText: "Изменение произошло успешно",
           caption: "Успех",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        UpdateCommand = new RelayCommand(executeAction: ExecuteUpdateCommand,
            canExecuteFunc: CanExecuteUpdateCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

        _selectedIndex = null;
        OnPropertyChanged(nameof(SelectedIndex));

        _lastItemId = null;
    }

    private async Task InitializeData()
    {
        Items = await _foodService.GetFoodListAsync();
    }

    private async Task AutoUpdateData(int secondsTimeout, bool isEnable)
    {
        // First loading data

        await InitializeData();

        int millisecondsTimeout = secondsTimeout *= 1000;

        while (isEnable)
        {
            Thread.Sleep(millisecondsTimeout: millisecondsTimeout);

            await InitializeData();
        }
    }

    #endregion
}