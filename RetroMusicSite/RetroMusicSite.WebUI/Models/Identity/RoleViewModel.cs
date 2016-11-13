using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RetroMusicSite.Domain.Entities.Identity;

namespace RetroMusicSite.WebUI.Models.Identity
{
    public class RoleViewModel
    {
        public class RoleEditModel
        {
            public AppRole Role { get; set; }
            public IEnumerable<AppUser> Members { get; set; }
            public IEnumerable<AppUser> NonMembers { get; set; }
        }

        public class RoleModificationModel
        {
            [Required]
            public string RoleName { get; set; }
            public string[] IdsToAdd { get; set; }
            public string[] IdsToDelete { get; set; }
        }
    }
}