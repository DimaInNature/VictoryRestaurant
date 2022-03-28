namespace Desktop.Presentation.ViewModels.Abstract.Base;

internal abstract class BaseReadViewModel<T>
    : BaseViewModel where T : IDomainModel
{
    public List<T> Items
    {
        get => _items;
        set
        {
            if (value is not null)
                _items = value;

            OnPropertyChanged(nameof(Items));
        }
    }

    public T? SelectedItem
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
            }
        }
    }

    protected List<T> _items = new();

    protected T? _selectedItem;

    protected int? _lastItemId;
}