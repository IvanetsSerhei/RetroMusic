using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using RetroMusicSite.Domain.Abstract;
using RetroMusicSite.Domain.Entities;
using RetroMusicSite.Domain.Infrastructure;

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
        public AppUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>(); }
        }
        public AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
    }
}
