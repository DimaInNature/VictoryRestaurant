namespace Desktop.Presentation.ViewModels.UserControls.Foods;

internal sealed class FoodsViewModel
    : BaseMenuViewModel, IFoodsViewModel
{
    public FoodsViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadFoodsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadFoodsView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateFoodsView();

    private void ExecuteShowUpdatePage(object obj) =>
        FrameSource = new UpdateFoodsView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteFoodsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadFoodsView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateFoodsView;

    private bool CanExecuteShowUpdatePage(object obj) =>
        FrameSource is not UpdateFoodsView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteFoodsView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowReadPageCommand = new RelayCommand(executeAction: ExecuteShowReadPage,
            canExecuteFunc: CanExecuteShowReadPage);

        ShowCreatePageCommand = new RelayCommand(executeAction: ExecuteShowCreatePage,
           canExecuteFunc: CanExecuteShowCreatePage);

        ShowUpdatePageCommand = new RelayCommand(executeAction: ExecuteShowUpdatePage,
            canExecuteFunc: CanExecuteShowUpdatePage);

        ShowDeletePageCommand = new RelayCommand(executeAction: ExecuteShowDeletePage,
            canExecuteFunc: CanExecuteDeletePage);
    }

    #endregion
}