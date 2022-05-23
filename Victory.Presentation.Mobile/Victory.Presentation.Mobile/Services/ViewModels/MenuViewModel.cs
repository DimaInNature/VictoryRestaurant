using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;

namespace Victory.Presentation.Mobile.Services.ViewModels;

internal sealed class MenuViewModel : BaseViewModel
{
    #region Members

    public LayoutState MainState
    {
        get => _mainState;
        set
        {
            _mainState = value;

            OnPropertyChanged(nameof(MainState));
        }
    }

    public List<Food> MenuList
    {
        get => _menuList;
        set
        {
            _menuList = value ?? new();

            OnPropertyChanged(nameof(MenuList));
        }
    }

    public ICommand BackCommand =>
       new Command(execute: () => Application.Current.MainPage.Navigation.PopAsync());

    public ICommand UpdateCommand =>
       new Command(execute: () => InitializeData());

    private List<Food> _menuList = new();

    private LayoutState _mainState;

    private readonly IFoodRepositoryService _foodRepository;

    #endregion

    public MenuViewModel(IFoodRepositoryService foodRepository)
    {
        MainState = LayoutState.Loading;

        _foodRepository = foodRepository;

        Task.Run(InitializeData);
    }

    private async void InitializeData()
    {
        MainState = LayoutState.Loading;

        var current = Connectivity.NetworkAccess;

        if (current == NetworkAccess.Internet)
        {
            MenuList = await _foodRepository.GetFoodListAsync();

            MainState = LayoutState.None;
        }
        else
            MainState = LayoutState.Empty;
    }
}