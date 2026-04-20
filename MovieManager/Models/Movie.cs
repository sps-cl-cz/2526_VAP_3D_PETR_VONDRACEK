using SQLite;

namespace MovieManager.Models
{
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
