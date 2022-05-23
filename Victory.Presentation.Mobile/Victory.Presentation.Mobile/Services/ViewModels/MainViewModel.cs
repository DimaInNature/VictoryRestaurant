namespace Victory.Presentation.Mobile.Services.ViewModels
{
    internal sealed class MainViewModel : BaseViewModel
    {
        public List<Pick> Picks { get; set; }

        public List<MenuObject> MyMenu { get; set; }

        public ICommand BookingCommand =>
            new Command(execute: () => Application.Current.MainPage.Navigation.PushAsync(page: new BookingView()));

        public ICommand MenuCommand =>
           new Command(execute: () => Application.Current.MainPage.Navigation.PushAsync(page: new MenuView()));

        public MainViewModel()
        {
            Picks = GetPicks();

            MyMenu = GetMenus();
        }

        private List<Pick> GetPicks() =>
            new()
            {
                new Pick { Title = "Завтрак", Image = "IMG01.png",
                    Description = "Божественный завтрак - праздник утра!" },

                 new Pick { Title = "Обед", Image = "IMG02.png",
                    Description = "Не откладывай до ужина того, что можешь съесть за обедом.\n© А.С. Пушкин" },

                new Pick { Title = "Ужин", Image = "IMG03.png",
                    Description = "Мы все суетимся и бегаем, а ведь в ресторане Victory всегда ждёт подогретый ужин." }
            };

        private List<MenuObject> GetMenus() => new()
        {
            new (){ Name = "Главная"},
            new (){
                Name = "Заказать",
                MenuCommand = BookingCommand},
            new (){
                Name = "Меню",
                MenuCommand = MenuCommand}
        };
    }
}