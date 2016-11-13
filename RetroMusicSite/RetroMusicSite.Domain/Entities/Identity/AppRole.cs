using Microsoft.AspNet.Identity.EntityFramework;

namespace RetroMusicSite.Domain.Entities.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name)
            : base(name)
        { }
    }
}
