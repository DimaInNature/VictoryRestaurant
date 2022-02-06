using Desktop.Presentation.ViewModels.UserControls;
using System.Windows.Controls;
using VictoryRestaurant.Desktop.Presentation;

namespace Desktop.Presentation.Views.UserControls;

public partial class FoodView : UserControl
{
    public FoodView()
    {
        InitializeComponent();
        DataContext = (Application.Current as App)?
               .ServiceProvider.GetService<FoodViewModel>();
    }
}
