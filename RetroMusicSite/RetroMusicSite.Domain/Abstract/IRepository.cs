using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using RetroMusicSite.Domain.Entities;
using RetroMusicSite.Domain.Infrastructure;

namespace RetroMusicSite.Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<Artist> Artists { get; }
        IEnumerable<Audio> Audios { get; }
        AppUserManager UserManager { get; }
        AppRoleManager RoleManager { get; }
    }
}