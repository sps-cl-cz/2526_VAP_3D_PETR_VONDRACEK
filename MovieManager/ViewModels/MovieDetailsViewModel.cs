using MovieManager.Database;
using MovieManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MovieManager.ViewModels
{
    [QueryProperty(nameof(Movie), "Movie")]
    public class MovieDetailsViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _db;
        private readonly MainViewModel _mainViewModel;

        private MovieViewModel? _movie;
        public MovieViewModel? Movie
        {
            get => _movie;
            set
            {
                _movie = value;
                OnPropertyChanged();
                // Copy values into editable fields
                if (_movie != null)
                {
                    EditTitle = _movie.Title;
                    EditDescription = _movie.Description;
                    EditYear = _movie.Year.ToString();
                    EditGenre = _movie.Genre;
                    EditRating = _movie.Rating.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    EditImageUrl = _movie.ImageUrl;
                }
            }
        }

        private string _editTitle = string.Empty;
        private string _editDescription = string.Empty;
        private string _editYear = string.Empty;
        private string _editGenre = string.Empty;
        private string _editRating = string.Empty;
        private string _editImageUrl = string.Empty;

        public string EditTitle { get => _editTitle; set { _editTitle = value; OnPropertyChanged(); } }
        public string EditDescription { get => _editDescription; set { _editDescription = value; OnPropertyChanged(); } }
        public string EditYear { get => _editYear; set { _editYear = value; OnPropertyChanged(); } }
        public string EditGenre { get => _editGenre; set { _editGenre = value; OnPropertyChanged(); } }
        public string EditRating { get => _editRating; set { _editRating = value; OnPropertyChanged(); } }
        public string EditImageUrl { get => _editImageUrl; set { _editImageUrl = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; }

        public MovieDetailsViewModel(DatabaseService db, MainViewModel mainViewModel)
        {
            _db = db;
            _mainViewModel = mainViewModel;
            SaveCommand = new Command(async () => await SaveAsync());
        }

        private async Task SaveAsync()
        {
            if (_movie == null) return;

            _movie.Title = EditTitle;
            _movie.Description = EditDescription;
            _movie.Year = int.TryParse(EditYear, out int y) ? y : 0;
            _movie.Genre = EditGenre;
            _movie.Rating = double.TryParse(EditRating, System.Globalization.NumberStyles.Any,
                                System.Globalization.CultureInfo.InvariantCulture, out double r) ? r : 0;
            _movie.ImageUrl = EditImageUrl;

            await _db.SaveMovieAsync(_movie.Movie);
            await _mainViewModel.LoadMoviesAsync();

            await Shell.Current.DisplayAlert("Hotovo", "Změny byly uloženy.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
