using System.Web.Mvc;
using RetroMusicSite.Domain.Abstract;

namespace RetroMusicSite.WebUI.Controllers
{
    public class MusicController : Controller
    {
        private IRepository _repository;

        public MusicController(IRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Audio()
        {
            return View(_repository.Audios);
        }

    }
}