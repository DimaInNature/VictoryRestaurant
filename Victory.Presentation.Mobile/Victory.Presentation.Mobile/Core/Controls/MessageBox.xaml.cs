namespace Victory.Presentation.Mobile.Core.Controls;

[XamarinXaml.XamlCompilation(XamarinXaml.XamlCompilationOptions.Compile)]
public partial class MessageBox : PopupPage
{
    public MessageBox() => InitializeComponent();

    public MessageBox(string title, string content) : this() =>
        (TitleLabel.Text, ContentLabel.Text) = (title, content);

    private async void ContinueButton_Clicked(object sender, System.EventArgs e) =>
        await Application.Current.MainPage.Navigation.PopPopupAsync(animate: true);
}