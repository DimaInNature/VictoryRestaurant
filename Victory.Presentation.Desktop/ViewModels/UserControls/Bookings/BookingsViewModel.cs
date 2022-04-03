namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class BookingsViewModel
    : BaseMenuViewModel, IBookingsViewModel
{
    public BookingsViewModel()
    {
        InitializeCommands();

        FrameSource = new ReadBookingsView();
    }

    #region Command Logic

    #region Execute

    private void ExecuteShowReadPage(object obj) =>
        FrameSource = new ReadBookingsView();

    private void ExecuteShowDeletePage(object obj) =>
        FrameSource = new DeleteBookingsView();

    #endregion

    #region Can Execute

    private bool CanExecuteShowReadPage(object obj) =>
        FrameSource is not ReadBookingsView;

    private bool CanExecuteDeletePage(object obj) =>
        FrameSource is not DeleteBookingsView;

    #endregion

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        ShowReadPageCommand = new RelayCommand(executeAction: ExecuteShowReadPage,
            canExecuteFunc: CanExecuteShowReadPage);

        ShowDeletePageCommand = new RelayCommand(executeAction: ExecuteShowDeletePage,
            canExecuteFunc: CanExecuteDeletePage);
    }

    #endregion
}