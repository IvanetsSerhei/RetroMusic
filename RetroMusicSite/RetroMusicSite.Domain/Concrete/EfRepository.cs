using System.Collections.Generic;
using RetroMusicSite.Domain.Abstract;
using RetroMusicSite.Domain.Entities;

namespace RetroMusicSite.Domain.Concrete
{
    public class EfRepository : IRepository
    {
        EfDbContext _context = new EfDbContext();

        public IEnumerable<Artist> Artists
        {
            get { return _context.Artists; }
        }
        public IEnumerable<Audio> Audios
        {
            get { return _context.Audios; }
        }
    }
}
