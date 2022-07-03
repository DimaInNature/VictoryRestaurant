namespace Victory.Presentation.Desktop.MVVM.ViewModels;

public abstract class BaseCreateViewModel : BaseViewModel
{
    public ICommand? CreateCommand { get; protected set; }

    protected abstract bool CanExecuteCreate(object obj);

    protected abstract void ExecuteCreate(object obj);
}