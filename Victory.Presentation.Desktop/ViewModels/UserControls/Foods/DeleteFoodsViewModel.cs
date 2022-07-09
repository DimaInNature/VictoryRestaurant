namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class DeleteFoodsViewModel : BaseDeleteViewModel<Food>
{
    private readonly IFoodFacadeService _foodService;

    private readonly UserSessionService _userSessionService;

    public DeleteFoodsViewModel(
        IFoodFacadeService foodService,
        UserSessionService userSessionService)
    {
        (_foodService, _userSessionService) = (foodService, userSessionService);

        InitializeCommands();

        Task.Run(function: () => InitializeData());
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedGeneralValue is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        string? token = _userSessionService.JwtToken;

        if (SelectedGeneralValue is null || string.IsNullOrWhiteSpace(value: token)) return;

        await _foodService.DeleteAsync(id: SelectedGeneralValue.Id, token);

        MessageBox.Show(
           messageBoxText: "The deletion was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        await InitializeData();

        Clear();
    }

    #endregion

    #region Other Logic

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

    protected override void SelectGeneralValue() { }

    protected async override Task UpdateData() => await InitializeData();

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private async Task InitializeData()
    {
        GeneralDataList = await _foodService.GetFoodListAsync();
    }

    #endregion
}