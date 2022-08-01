namespace Victory.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseReadViewModel<TGeneralType>
    : BaseViewModel where TGeneralType : IDomainModel
{
    #region Properties

    public List<TGeneralType> GeneralDataList
    {
        get => _generalDataList ?? new();
        set
        {
            _generalDataList = value;

            OnPropertyChanged(nameof(GeneralDataList));
        }
    }

    public TGeneralType? SelectedGeneralValue
    {
        get => _selectedGeneralValue;
        set
        {
            _selectedGeneralValue = value;

            OnPropertyChanged(nameof(SelectedGeneralValue));

            if (value is not null)
            {
                SelectGeneralValue();
            }
        }
    }

    public string SearchFilter
    {
        get => _searchFilter ?? string.Empty;
        set
        {
            _searchFilter = value;

            OnPropertyChanged(nameof(SearchFilter));

            if (string.IsNullOrWhiteSpace(value) is false)
            {
                Find(filter: value);

                return;
            }

            UpdateData();
        }
    }

    private List<TGeneralType> _generalDataList = new();

    private TGeneralType? _selectedGeneralValue;

    private string _searchFilter = string.Empty;

    #endregion

    #region Methods

    protected abstract void SelectGeneralValue();

    protected abstract void Find(string filter);

    protected abstract Task UpdateData();

    #endregion
}
