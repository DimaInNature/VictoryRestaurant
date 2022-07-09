namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal sealed class CreateTablesViewModel : BaseCreateViewModel
{
    #region Members

    #region Properties

    public int? Number
    {
        get => _number;
        set
        {
            int maxLenght = 999;

            if (value > maxLenght) return;

            if (value > 0 || value is null)
            {
                _number = value;

                OnPropertyChanged(nameof(Number));
            }
        }
    }

    #endregion

    #region Private

    private int? _number;

    #endregion

    #region Dependencies

    private readonly ITableFacadeService _tableRepository;

    private readonly UserSessionService _userSessionService;

    #endregion

    #endregion

    public CreateTablesViewModel(
        ITableFacadeService tableRepository,
        UserSessionService userSessionService)
    {
        (_tableRepository, _userSessionService) = (tableRepository, userSessionService);

        InitializeCommands();
    }

    #region Command Logic

    protected override bool CanExecuteCreate(object obj) => Number > 0;

    protected override async void ExecuteCreate(object obj)
    {
        string? token = _userSessionService.JwtToken;

        if (Number is null || Number < 1 || string.IsNullOrWhiteSpace(value: token)) return;

        var tables = await _tableRepository.GetTableListAsync(number: (int)Number);

        if (tables.Count > 0)
        {
            MessageBox.Show(
                messageBoxText: "The table already exists",
                caption: "Information",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Exclamation);

            return;
        }

        Table table = new()
        {
            Number = (int)Number,
            Status = "Free",
            BookingId = default
        };

        await _tableRepository.CreateAsync(entity: table, token);

        MessageBox.Show(
            messageBoxText: "The addition was successful",
            caption: "Success",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(executeAction: ExecuteCreate,
            canExecuteFunc: CanExecuteCreate);
    }

    private void Clear()
    {
        Number = null;
    }

    #endregion
}