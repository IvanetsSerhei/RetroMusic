using System.ComponentModel.DataAnnotations;

namespace RetroMusicSite.WebUI.Models.Identity
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}