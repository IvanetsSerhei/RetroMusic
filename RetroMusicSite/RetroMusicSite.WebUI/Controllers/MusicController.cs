using System.Linq;
using System.Web.Mvc;
using RetroMusicSite.Domain.Abstract;

namespace RetroMusicSite.WebUI.Controllers
{
    public class MusicController : Controller
    {
        private IRepository _repository;
        public int pageSizeAudio = 50; 

        public MusicController(IRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Audio(int page=1)
        {
            return View(_repository.Audios
                .OrderBy(audio=> audio.AudioId)
                .Skip((page -1) * pageSizeAudio)
                .Take(pageSizeAudio));
        }

    }
}