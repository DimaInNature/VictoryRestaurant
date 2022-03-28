﻿namespace Desktop.Presentation.ViewModels.UserControls.Foods;

internal sealed class DeleteFoodsViewModel
    : BaseDeleteViewModel<Food>, IDeleteFoodsViewModel
{
    private readonly IFoodFacadeService _foodService;

    public DeleteFoodsViewModel(IFoodFacadeService foodService)
    {
        _foodService = foodService;

        InitializeCommands();

        Task.Run(function: () => AutoUpdateData(
           secondsTimeout: ApplicationConfiguration.AutoUpdateSecondsTimeout,
           isEnable: ApplicationConfiguration.AutoUpdateIsEnable));
    }

    #region Command Logic

    protected override bool CanExecuteDeleteCommand(object obj) =>
        SelectedItem is not null;

    protected override async void ExecuteDeleteCommand(object obj)
    {
        if (SelectedItem is null) return;

        await _foodService.DeleteAsync(SelectedItem.Id);

        MessageBox.Show(
           messageBoxText: "Удаление произошло успешно",
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
        DeleteCommand = new RelayCommand(executeAction: ExecuteDeleteCommand,
            canExecuteFunc: CanExecuteDeleteCommand);
    }

    private void Clear()
    {
        _selectedItem = null;
        OnPropertyChanged(nameof(SelectedItem));

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