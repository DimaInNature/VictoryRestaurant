using System.Collections.Generic;
using System.Threading.Tasks;
using VictoryRestaurant.Domain;

namespace Desktop.Presentation.ViewModels.UserControls;

public class FoodViewModel : BaseViewModel
{
    private readonly IFoodRepositoryService _foodRepository;

    public FoodViewModel(IFoodRepositoryService foodRepository)
    {
        _foodRepository = foodRepository;
        Task.Run(InitializeData);
    }

    #region Properties

    #region Data

    public IEnumerable<Food> Foods
    {
        get => _foods;
        set
        {
            if (value is not null)
                _foods = value;
            OnPropertyChanged(nameof(Foods));
        }
    }

    private IEnumerable<Food> _foods;

    #endregion

    #endregion

    #region Other Methods

    private async Task InitializeData()
    {
        Foods = await _foodRepository.GetFoodsAsync();
    }

    #endregion
}
