namespace RestaurantyApp;

public partial class MapRoutePage : ContentPage
{
    public MapRoutePage(double startLat, double startLon, double destLat, double destLon, string restaurantName = "Restaurace")
    {
        InitializeComponent();

        Title = restaurantName;
        InfoLabel.Text = $"Trasa pěšky → {restaurantName}";
        string sLat = startLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
        string sLon = startLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
        string dLat = destLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
        string dLon = destLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
        string mapUrl = $"https://www.google.com/maps/dir/?api=1" +
                        $"&origin={sLat},{sLon}" +
                        $"&destination={dLat},{dLon}" +
                        $"&travelmode=walking";

        MapWebView.Source = mapUrl;
    }
    private void OnMapNavigated(object sender, WebNavigatedEventArgs e)
    {
        if (e.Result == WebNavigationResult.Success)
            InfoLabel.IsVisible = false;
        else
            InfoLabel.Text = "Mapu se nepodařilo načíst. Zkontroluj připojení k internetu.";
    }
}
