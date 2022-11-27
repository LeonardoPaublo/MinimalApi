namespace MoviesApi.Models
{
    public partial class Content
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AgeGroup { get; set; }
        public string Genres { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Director { get; set; } = string.Empty;
        public string Screenwriter { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal BoxOfficeRevenue { get; set; }
        public string Language { get; set; } = string.Empty;
        public decimal Duration { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Type { get; set; }

        public enum ContentType {
            Movie = 1,
            TvShow = 2,
            Series = 3,
        }
    }
}
