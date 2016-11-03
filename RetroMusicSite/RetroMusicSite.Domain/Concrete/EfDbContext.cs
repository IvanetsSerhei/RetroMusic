using System.Data.Entity;
using RetroMusicSite.Domain.Entities;


namespace RetroMusicSite.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
