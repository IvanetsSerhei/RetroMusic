using System.Collections.Generic;
using RetroMusicSite.Domain.Entities;

namespace RetroMusicSite.WebUI.Models
{
    public class ArtistViewModels
    {
        public IEnumerable<Artist> Artists { get; set; }
        public int CurrentCategory { get; set; }
    }
}