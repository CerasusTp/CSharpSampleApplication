namespace SampleApplication.Models.DB
{
    public class StreamerURL
    {
        public int Id { get; set; }
        public int StreamerId { get; set; }
        public required string Site { get; set; }
        public required string Url { get; set; }
        public virtual required Streamer Streamer { get; set; }
    }
}
