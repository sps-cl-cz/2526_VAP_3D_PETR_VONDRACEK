using MovieManager.Database;
using MovieManager.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _db;

        public ObservableCollection<MovieViewModel> Movies { get; } = new();

        public MainViewModel(DatabaseService db)
        {
            _db = db;
        }

        public async Task LoadMoviesAsync()
        {
            var movies = await _db.GetMoviesAsync();
            Movies.Clear();
            foreach (var m in movies)
                Movies.Add(new MovieViewModel(m));
        }

        public async Task DeleteMovieAsync(MovieViewModel vm)
        {
            await _db.DeleteMovieAsync(vm.Movie);
            Movies.Remove(vm);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
