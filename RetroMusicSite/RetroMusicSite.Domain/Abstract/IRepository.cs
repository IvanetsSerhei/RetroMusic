using System.Collections.Generic;
using RetroMusicSite.Domain.Entities;

namespace RetroMusicSite.Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<Artist> Artists { get; }
        IEnumerable<Audio> Audios { get; }
    }
}