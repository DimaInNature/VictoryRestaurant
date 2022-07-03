namespace Victory.Presentation.Desktop.MVVM.ViewModels;

public abstract class BaseDeleteViewModel<TGeneralType>
    : BaseReadViewModel<TGeneralType> where TGeneralType : IDomainModel
{
    public ICommand? DeleteCommand { get; protected set; }

    protected abstract bool CanExecuteDeleteCommand(object obj);

    protected abstract void ExecuteDeleteCommand(object obj);

    protected virtual void Clear()
    {
        SelectedGeneralValue = default;
    }
}