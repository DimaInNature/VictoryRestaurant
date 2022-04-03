namespace Victory.Infra.Core.Desktop.ViewModels;

public abstract class BaseMenuViewModel : BaseViewModel
{
    public ICommand? ShowCreatePageCommand { get; protected set; }

    public ICommand? ShowReadPageCommand { get; protected set; }

    public ICommand? ShowUpdatePageCommand { get; protected set; }

    public ICommand? ShowDeletePageCommand { get; protected set; }

    public object? FrameSource
    {
        get => _frameSource;
        set
        {
            _frameSource = value;

            OnPropertyChanged(nameof(FrameSource));
        }
    }

    private object? _frameSource;
}