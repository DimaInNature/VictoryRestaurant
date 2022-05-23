namespace Victory.Presentation.Mobile.Services.ViewModels;

public sealed class BookingViewModel : BaseViewModel
{
    #region Members

    #region Properties

    public bool AllPropertiesIsValid
    {
        get => _propertiesIsValid;
        set
        {
            _propertiesIsValid = value;

            OnPropertyChanged(nameof(AllPropertiesIsValid));
        }
    }

    public string SelectedPersonCount
    {
        get => _selectedPersonCount ?? string.Empty;
        set
        {
            _selectedPersonCount = value;

            OnPropertyChanged(nameof(SelectedPersonCount));

            AllPropertiesIsValid = ValidateAllProperties();
        }
    }

    public string SelectedDay
    {
        get => _selectedDay ?? string.Empty;
        set
        {
            _selectedDay = value;

            OnPropertyChanged(nameof(SelectedDay));

            AllPropertiesIsValid = ValidateAllProperties();
        }
    }

    public string SelectedTime
    {
        get => _selectedTime ?? string.Empty;
        set
        {
            _selectedTime = value;

            OnPropertyChanged(nameof(SelectedTime));

            AllPropertiesIsValid = ValidateAllProperties();
        }
    }

    public string ClientName
    {
        get => _clientName ?? string.Empty;
        set
        {
            _clientName = value;

            OnPropertyChanged(nameof(ClientName));

            AllPropertiesIsValid = ValidateAllProperties();
        }
    }

    public string ClientPhone
    {
        get => _clientPhone ?? string.Empty;
        set
        {
            Regex regex = new(pattern: @"^([\(\)\+0-9\s\-\#]+)$");

            _clientPhone = regex.IsMatch(value) && value.Length < 17
                ? value
                : string.Empty;

            OnPropertyChanged(nameof(ClientPhone));

            AllPropertiesIsValid = ValidateAllProperties();
        }
    }

    #endregion

    #region Private

    private string? _selectedPersonCount;

    private string? _selectedTime;

    private string? _selectedDay;

    private string? _clientName;

    private string? _clientPhone;

    private bool _propertiesIsValid = false;

    #endregion

    #region Commands

    public ICommand BackCommand =>
        new Command(execute: () => Application.Current.MainPage.Navigation.PopAsync());

    public ICommand? CreateBookingCommand { get; private set; }

    #endregion

    #region Dependencies

    private IBookingRepositoryService _bookingRepository;

    #endregion

    #endregion

    public BookingViewModel(IBookingRepositoryService repository)
    {
        _bookingRepository = repository;

        InitializeCommands();
    }

    private async void ExecuteCreateBooking(object obj)
    {
        var pop = new MessageBox(title: "Успех!", content: "Вы успешно забронировали столик!");

        await Application.Current.MainPage.Navigation.PushPopupAsync(page: pop, animate: true);

        Booking booking = Booking.GetBuilder()
            .SetTime(time: SelectedTime)
            .SetName(name: ClientName)
            .SetPhone(phone: ClientPhone)
            .SetDayOfWeek(dayOfWeek: SelectedDay)
            .SetPersonCount(countStr: SelectedPersonCount)
            .Build();

        await _bookingRepository.CreateAsync(entity: booking);

        Clear();
    }

    private void Clear() => ClientName = ClientPhone =
        SelectedDay = SelectedTime = SelectedPersonCount = string.Empty;

    private bool CanExecuteCreateBooking(object obj) => AllPropertiesIsValid;

    private bool ValidateAllProperties() =>
        ClientName.Length > 1 && ClientPhone.Length > 5 &&
        string.IsNullOrWhiteSpace(SelectedDay) is false &&
        string.IsNullOrWhiteSpace(SelectedTime) is false &&
        string.IsNullOrWhiteSpace(SelectedPersonCount) is false;

    private void InitializeCommands() =>
        CreateBookingCommand = new Command(
            execute: ExecuteCreateBooking,
            canExecute: CanExecuteCreateBooking);
}