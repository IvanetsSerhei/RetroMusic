using System.Collections.Generic;
using RetroMusicSite.Domain.Entities;

namespace RetroMusicSite.WebUI.Models
{
    public class AudioViewModels
    {
        public IEnumerable<Audio> Audios { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}