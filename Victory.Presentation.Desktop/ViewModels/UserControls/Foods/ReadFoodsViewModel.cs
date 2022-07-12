namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class ReadFoodsViewModel : BaseReadViewModel<Food>
{
    private readonly IFoodRepositoryService _foodRepository;

    public ReadFoodsViewModel(IFoodRepositoryService foodRepository)
    {
        _foodRepository = foodRepository;

        Task.Run(function: () => InitializeData());
    }

    #region Other Logic

    protected override async void Find(string filter)
    {
        var foods = await _foodRepository.GetFoodListAsync();

        filter = filter.ToLower();

        GeneralDataList = foods.Where(
            predicate: food =>
            food.Name.ToLower().Contains(value: filter) |
            food.Description.ToLower().Contains(value: filter))
            .ToList();
    }

    protected async override Task UpdateData() => await InitializeData();

    protected override void SelectGeneralValue() { }

    private async Task InitializeData() =>
        GeneralDataList = await _foodRepository.GetFoodListAsync();

    #endregion
}