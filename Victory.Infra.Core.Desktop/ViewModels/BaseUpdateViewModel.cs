namespace Victory.Infra.Core.Desktop.ViewModels;

public abstract class BaseUpdateViewModel<T>
    : BaseReadViewModel<T> where T : IDomainModel
{
    public ICommand? UpdateCommand { get; protected set; }

    public new T? SelectedItem
    {
        get => _selectedItem;
        set
        {
            // If the object has not been selected yet

            if (_lastItemId is null)
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));

                if (_selectedItem is null) return;

                _lastItemId = _selectedItem.Id;

                if (typeof(T) == typeof(Food))
                {
                    _selectedIndex = (int?)(_selectedItem as Food)?.Type;
                    OnPropertyChanged(nameof(SelectedIndex));
                }
                else if (typeof(T) == typeof(User))
                {
                    _selectedIndex = (int?)(_selectedItem as User)?.Role;
                    OnPropertyChanged(nameof(SelectedIndex));
                }
            }

            // if the object was selected and the data was updated

            else if (_selectedItem is null)
            {
                _selectedItem = _items.Find(food => food.Id == _lastItemId);

                OnPropertyChanged(nameof(SelectedItem));
            }

            // Allow the selection of another object
            // if the data has not been updated yet

            else if (value is not null)
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));

                if (typeof(T) == typeof(Food))
                {
                    _selectedIndex = (int?)(_selectedItem as Food)?.Type;
                    OnPropertyChanged(nameof(SelectedIndex));
                }
                else if (typeof(T) == typeof(User))
                {
                    _selectedIndex = (int?)(_selectedItem as User)?.Role;
                    OnPropertyChanged(nameof(SelectedIndex));
                }
            }
        }
    }

    public int? SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (value is not null)
            {
                _selectedIndex = value;

                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
    }

    protected int? _selectedIndex;

    protected abstract bool CanExecuteUpdateCommand(object obj);

    protected abstract void ExecuteUpdateCommand(object obj);
}