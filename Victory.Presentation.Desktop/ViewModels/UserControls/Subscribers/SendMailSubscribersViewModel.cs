namespace Victory.Presentation.Desktop.ViewModels.UserControls;

internal class SendMailSubscribersViewModel : BaseViewModel, ISendMailSubscribersViewModel
{
    public string Subject
    {
        get => _subject ?? string.Empty;
        set
        {
            _subject = value;

            OnPropertyChanged(nameof(Subject));
        }
    }

    public string Message
    {
        get => _message ?? string.Empty;
        set
        {
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
        await _emailService
           .AddMailSender(userName: ApplicationConfiguration.MailSenderUserName, password: ApplicationConfiguration.MailSenderPassword)
           .ConfigureSMTP(host: "smtp.yandex.ru", port: 25)
           .AddMessage(subject: Subject, message: Message)
           .SendAsync();

        MessageBox.Show(
           messageBoxText: "Отправление произошло успешно",
           caption: "Успех",
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