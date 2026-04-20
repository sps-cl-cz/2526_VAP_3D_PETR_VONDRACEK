using MovieManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieManager.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private Movie _movie;

        public MovieViewModel(Movie movie)
        {
            _movie = movie;
        }

        public Movie Movie => _movie;

        public int Id => _movie.Id;

        public string Title
        {
            get => _movie.Title;
            set { _movie.Title = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _movie.Description;
            set { _movie.Description = value; OnPropertyChanged(); }
        }

        public int Year
        {
            get => _movie.Year;
            set { _movie.Year = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get => _movie.Genre;
            set { _movie.Genre = value; OnPropertyChanged(); }
        }

        public double Rating
        {
            get => _movie.Rating;
            set { _movie.Rating = value; OnPropertyChanged(); }
        }

        public string ImageUrl
        {
            get => _movie.ImageUrl;
            set { _movie.ImageUrl = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
