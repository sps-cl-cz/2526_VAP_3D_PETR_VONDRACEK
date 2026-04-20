using MovieManager.Database;
using MovieManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MovieManager.ViewModels
{
    public class NewMovieViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _db;
        private readonly MainViewModel _mainViewModel;

        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _year = string.Empty;
        private string _genre = string.Empty;
        private string _rating = string.Empty;
        private string _imageUrl = string.Empty;

        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string Year { get => _year; set { _year = value; OnPropertyChanged(); } }
        public string Genre { get => _genre; set { _genre = value; OnPropertyChanged(); } }
        public string Rating { get => _rating; set { _rating = value; OnPropertyChanged(); } }
        public string ImageUrl { get => _imageUrl; set { _imageUrl = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; }

        public NewMovieViewModel(DatabaseService db, MainViewModel mainViewModel)
        {
            _db = db;
            _mainViewModel = mainViewModel;
            SaveCommand = new Command(async () => await SaveAsync());
        }

        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                await Shell.Current.DisplayAlert("Chyba", "Název filmu je povinný.", "OK");
                return;
            }

            var movie = new Movie
            {
                Title = Title,
                Description = Description,
                Year = int.TryParse(Year, out int y) ? y : 0,
                Genre = Genre,
                Rating = double.TryParse(Rating, System.Globalization.NumberStyles.Any,
                             System.Globalization.CultureInfo.InvariantCulture, out double r) ? r : 0,
                ImageUrl = ImageUrl
            };

            await _db.SaveMovieAsync(movie);
            await _mainViewModel.LoadMoviesAsync();

            // Reset form
            Title = string.Empty;
            Description = string.Empty;
            Year = string.Empty;
            Genre = string.Empty;
            Rating = string.Empty;
            ImageUrl = string.Empty;

            await Shell.Current.DisplayAlert("Hotovo", "Film byl přidán.", "OK");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
