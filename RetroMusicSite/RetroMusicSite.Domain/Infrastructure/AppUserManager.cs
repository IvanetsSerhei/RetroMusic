using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RetroMusicSite.Domain.Concrete;
using RetroMusicSite.Domain.Entities.Identity;
using RetroMusicSite.WebUI.Infrastructure.Identity;

namespace RetroMusicSite.Domain.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            EfDbContext db = context.Get<EfDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));

            manager.PasswordValidator = new CustomPasswordValidator();

            manager.UserValidator = new CustomUserValidator();

            return manager;
        }
    }
}
