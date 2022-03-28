namespace Desktop.Presentation.ViewModels.UserControls.Foods;

internal sealed class ReadFoodsViewModel
    : BaseReadViewModel<Food>, IReadFoodsViewModel
{
    private readonly IFoodFacadeService _foodRepository;

    public ReadFoodsViewModel(IFoodFacadeService foodRepository)
    {
        _foodRepository = foodRepository;

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Other Logic

    private async Task InitializeData()
    {
        Items = await _foodRepository.GetFoodListAsync();
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