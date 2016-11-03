using System.Linq;
using System.Web.Mvc;
using RetroMusicSite.Domain.Abstract;
using RetroMusicSite.WebUI.Models;

namespace RetroMusicSite.WebUI.Controllers
{
    public class MusicController : Controller
    {
        private IRepository _repository;
        public int pageSizeAudio = 35; 

        public MusicController(IRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Audio(int page=1)
        {
            AudioViewModels model = new AudioViewModels
            {
               Audios = _repository.Audios
                .OrderBy(audio=> audio.AudioId)
                .Skip((page -1) * pageSizeAudio)
                .Take(pageSizeAudio),
               PagingInfo = new PagingInfo
               {
                   CurrentPage = page,
                   ItemsPerPage = pageSizeAudio,
                   TotalItems = _repository.Audios.Count()
               }
            };
            return View(model);
        }

    }
}