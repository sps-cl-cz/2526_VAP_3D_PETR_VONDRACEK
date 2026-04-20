using MovieManager.Models;
using SQLite;

namespace MovieManager.Database
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "movies.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Movie>().Wait();
        }

        public Task<List<Movie>> GetMoviesAsync() =>
            _database.Table<Movie>().ToListAsync();

        public Task<Movie> GetMovieAsync(int id) =>
            _database.Table<Movie>().Where(m => m.Id == id).FirstOrDefaultAsync();

        public Task<int> SaveMovieAsync(Movie movie) =>
            movie.Id == 0 ? _database.InsertAsync(movie) : _database.UpdateAsync(movie);

        public Task<int> DeleteMovieAsync(Movie movie) =>
            _database.DeleteAsync(movie);
    }
}
