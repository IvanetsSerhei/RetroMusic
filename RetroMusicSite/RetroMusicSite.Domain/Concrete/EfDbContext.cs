using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetroMusicSite.Domain.Entities;
using RetroMusicSite.Domain.Entities.Identity;


namespace RetroMusicSite.Domain.Concrete
{
    public class EfDbContext : IdentityDbContext<AppUser>
    {
        public EfDbContext() : base("name=EFDbContext") { }

        public DbSet<Audio> Audios { get; set; }
        public DbSet<Artist> Artists { get; set; }

        static EfDbContext()
        {
            Database.SetInitializer<EfDbContext>(new IdentityDbInit());
        }

        public static EfDbContext Create()
        {
            return new EfDbContext();
        }
    }
    public class IdentityDbInit : NullDatabaseInitializer<EfDbContext>
    //    DropCreateDatabaseIfModelChanges<EfDbContext>
    {
    //    protected override void Seed(EfDbContext context)
    //    {
    //        PerformInitialSetup(context);
    //        base.Seed(context);
    //    }
    //    public void PerformInitialSetup(EfDbContext context)
    //    {
    //        // настройки конфигурации контекста будут указываться здесь
    //    }
    }
}

