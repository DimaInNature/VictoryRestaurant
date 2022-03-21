namespace Desktop.Presentation.ViewModels.UserControls;

public class FoodViewModel : BaseViewModel
{
    private readonly IFoodFacadeService _foodRepository;

    public FoodViewModel(IFoodFacadeService foodRepository)
    {
        _foodRepository = foodRepository;

        Task.Run(InitializeData);
    }

    #region Properties

    #region Data

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

    private List<Food> _foods = new();

    #endregion

    #endregion

    #region Other Methods

    private async Task InitializeData()
    {
        Foods = await _foodRepository.GetFoodsAsync();
    }

    #endregion
}