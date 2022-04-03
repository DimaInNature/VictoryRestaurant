namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class UsersViewModel
    : BaseMenuViewModel, IUsersViewModel
{
    public UsersViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadUsersView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadUsersView();

    private void ExecuteShowCreatePage(object obj) =>
        FrameSource = new CreateUsersView();

    private void ExecuteShowUpdatePage(object obj) =>
        FrameSource = new UpdateUsersView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteUsersView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadUsersView;

    private bool CanExecuteShowCreatePage(object obj) =>
        FrameSource is not CreateUsersView;

    private bool CanExecuteShowUpdatePage(object obj) =>
        FrameSource is not UpdateUsersView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteUsersView;

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