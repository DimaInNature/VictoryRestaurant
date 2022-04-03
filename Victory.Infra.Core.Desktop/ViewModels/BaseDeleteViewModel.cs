namespace Victory.Infra.Core.Desktop.ViewModels;

public abstract class BaseDeleteViewModel<T>
    : BaseReadViewModel<T> where T : IDomainModel
{
    public ICommand? DeleteCommand { get; protected set; }

    protected abstract bool CanExecuteDeleteCommand(object obj);

    protected abstract void ExecuteDeleteCommand(object obj);
}