namespace MoviesApi.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
