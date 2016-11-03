using System.Collections.Generic;

namespace RetroMusicSite.Domain.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int AlbumVkId { get; set; }
        public ICollection<Audio> Audios { get; set; }
        public int LanguageArtistId { get; set; }
    }

    public enum LanguageArtist
    {
        Russian,
        Foreign
    }
}
