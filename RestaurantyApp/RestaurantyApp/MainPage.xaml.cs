using System.Text.Json;
using RestaurantyApp.Models;

namespace RestaurantyApp;

public partial class MainPage : ContentPage
{
    private Location? _currentLocation;
    private readonly HttpClient _httpClient = new();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadDataAsync();
    }

    private async void OnRefreshClicked(object sender, EventArgs e)
    {
        RefreshButton.IsEnabled = false;
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;
        RestaurantsList.ItemsSource = null;
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                LocationLabel.Text = "⚠️ Oprávnění pro polohu bylo odepřeno";
                SetLoadingDone();
                return;
            }
            LocationLabel.Text = "Získávám polohu…";
            _currentLocation = await Geolocation.Default.GetLocationAsync(
                new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10)));

            if (_currentLocation == null)
            {
                LocationLabel.Text = "Nepodařilo se získat polohu";
                SetLoadingDone();
                return;
            }
            var placemarks = await Geocoding.Default.GetPlacemarksAsync(
                _currentLocation.Latitude, _currentLocation.Longitude);
            var placemark = placemarks?.FirstOrDefault();
            string cityName = placemark?.Locality ?? placemark?.SubAdminArea ?? "Neznámé místo";

            LocationLabel.Text = $"{cityName}";
            string lat = _currentLocation.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string lon = _currentLocation.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string url = $"https://photon.komoot.io/api/?osm_tag=amenity:restaurant&q={Uri.EscapeDataString(cityName)}&lat={lat}&lon={lon}&limit=50";

            var json = await _httpClient.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<PhotonResponse>(json);
            var restaurants = data?.Features
                .Where(f => !string.IsNullOrWhiteSpace(f.Properties?.Name))
                .ToList();

            RestaurantsList.ItemsSource = restaurants;
        }
        catch (FeatureNotSupportedException)
        {
            LocationLabel.Text = "GPS není na tomto zařízení podporováno";
        }
        catch (PermissionException)
        {
            LocationLabel.Text = "Přístup k poloze byl odepřen";
        }
        catch (Exception ex)
        {
            LocationLabel.Text = "Chyba při načítání dat";
            await DisplayAlert("Chyba", ex.Message, "OK");
        }
        finally
        {
            SetLoadingDone();
        }
    }
    private void SetLoadingDone()
    {
        LoadingIndicator.IsRunning = false;
        LoadingIndicator.IsVisible = false;
        RefreshButton.IsEnabled = true;
    }

    private async void OnRestaurantSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Feature selectedRestaurant)
            return;
        ((CollectionView)sender).SelectedItem = null;

        if (_currentLocation == null)
        {
            await DisplayAlert("Chyba", "Aktuální poloha není dostupná.", "OK");
            return;
        }

        if (selectedRestaurant.Geometry?.Coordinates?.Count < 2)
        {
            await DisplayAlert("Chyba", "Restaurace nemá platné souřadnice.", "OK");
            return;
        }
        double destLon = selectedRestaurant.Geometry.Coordinates[0];
        double destLat = selectedRestaurant.Geometry.Coordinates[1];
        string name = selectedRestaurant.Properties.Name ?? "Restaurace";

        await Navigation.PushAsync(new MapRoutePage(
            startLat: _currentLocation.Latitude,
            startLon: _currentLocation.Longitude,
            destLat: destLat,
            destLon: destLon,
            restaurantName: name));
    }
}
