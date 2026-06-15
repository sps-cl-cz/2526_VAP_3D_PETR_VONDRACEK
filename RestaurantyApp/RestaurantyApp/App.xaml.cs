namespace RestaurantyApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // NavigationPage umožňuje Navigation.PushAsync() v MainPage
        MainPage = new NavigationPage(new MainPage());
    }
}
