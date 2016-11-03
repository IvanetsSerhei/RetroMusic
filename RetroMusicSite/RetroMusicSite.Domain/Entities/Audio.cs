
namespace RetroMusicSite.Domain.Entities
{
    public class Audio
    {
        public int AudioId { get; set; }
        public string ArtistName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }      
        public int ArtistId { get; set; }
        public Artist Artists { get; set; }
    }
}
