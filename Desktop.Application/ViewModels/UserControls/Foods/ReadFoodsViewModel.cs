namespace Desktop.Presentation.ViewModels.UserControls.Foods;

internal sealed class ReadFoodsViewModel
    : BaseViewModel, IReadFoodsViewModel
{
    #region Members

    #region Properties

    public List<Food> Foods
    {
        get => _foods;
        set
        {
            if (value is not null)
                _foods = value;

            OnPropertyChanged(nameof(Foods));
        }
    }

    #endregion

    #region Private

    private List<Food> _foods = new();

    #endregion

    #region Dependencies

    private readonly IFoodFacadeService _foodRepository;

    #endregion

    #endregion

    public ReadFoodsViewModel(IFoodFacadeService foodRepository)
    {
        _foodRepository = foodRepository;

        Task.Run(function: InitializeData);
    }

    #region Other Logic

    private async Task InitializeData()
    {
        Foods = await _foodRepository.GetFoodsAsync();
    }

    #endregion
}