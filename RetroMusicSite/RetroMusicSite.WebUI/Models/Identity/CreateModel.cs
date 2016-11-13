using System.ComponentModel.DataAnnotations;


namespace RetroMusicSite.WebUI.Models.Identity
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }
    }
}