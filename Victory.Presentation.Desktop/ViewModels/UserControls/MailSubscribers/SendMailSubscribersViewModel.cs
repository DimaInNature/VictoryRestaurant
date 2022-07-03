namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal class SendMailSubscribersViewModel : BaseViewModel
{
    public string Subject
    {
        get => _subject ?? string.Empty;
        set
        {
            Regex trimmer = new(@"\s\s+", options: RegexOptions.Compiled);

            if (value == string.Empty)
            {
                _subject = null;

                OnPropertyChanged(nameof(Subject));

                return;
            }

            if (value.Length > 0)
            {
                if (char.IsWhiteSpace(c: value.FirstOrDefault()))
                    value = value.TrimStart(trimChar: ' ');
            }

            value = trimmer.Replace(input: value, replacement: " ");

            _subject = value;

            OnPropertyChanged(nameof(Subject));
        }
    }

    public string Message
    {
        get => _message ?? string.Empty;
        set
        {
            Regex trimmer = new(@"\s\s+", options: RegexOptions.Compiled);

            if (value == string.Empty)
            {
                _message = null;

                OnPropertyChanged(nameof(Message));

                return;
            }

            if (value.Length > 0)
            {
                if (char.IsWhiteSpace(c: value.FirstOrDefault()))
                    value = value.TrimStart(trimChar: ' ');
            }

            value = trimmer.Replace(input: value, replacement: " ");

            _message = value;

            OnPropertyChanged(nameof(Message));
        }
    }

    private string? _subject;

    private string? _message;

    public RelayCommand? SendMessageCommand { get; private set; }

    private readonly EmailService _emailService;

    public SendMailSubscribersViewModel(EmailService emailService)
    {
        _emailService = emailService;

        InitializeCommands();
    }

    #region Command Logic

    protected bool CanExecuteSendMessageCommand(object obj) =>
        StringHelper.StrIsNotNullOrWhiteSpace(Subject, Message);

    protected async void ExecuteSendMessageCommand(object obj)
    {
        await _emailService.SendAllAsync(message: new(Subject, text: Message));

        MessageBox.Show(
           messageBoxText: "Sending was successful",
           caption: "Success",
           button: MessageBoxButton.OK,
           icon: MessageBoxImage.Information);

        Clear();
    }

    #endregion

    #region Other Logic

    private void InitializeCommands()
    {
        SendMessageCommand = new RelayCommand(executeAction: ExecuteSendMessageCommand,
            canExecuteFunc: CanExecuteSendMessageCommand);
    }

    private void Clear() =>
        Message = Subject = string.Empty;

    #endregion
}