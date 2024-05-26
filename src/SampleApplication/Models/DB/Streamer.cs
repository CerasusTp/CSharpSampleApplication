namespace SampleApplication.Models.DB
{
    public class Streamer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Explanation { get; set; }
        public virtual ICollection<StreamerURL>? StreamerURLs { get; set; }
    }
}
