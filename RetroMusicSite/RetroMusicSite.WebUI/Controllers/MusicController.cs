using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RetroMusicSite.Domain.Abstract;
using RetroMusicSite.Domain.Entities;
using RetroMusicSite.WebUI.Models;

namespace RetroMusicSite.WebUI.Controllers
{
    public class MusicController : Controller
    {
        private IRepository _repository;

        public int pageSizeAudio = 35;
        public int pageSizeArtist = 42;

        public MusicController(IRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Artist(string category, int page = 1)
        {
            ArtistViewModels model = new ArtistViewModels();
            switch (category)
            {
                case "Русское":
                    model.Artists = _repository.Artists
                        .Where(p => p.LanguageArtistId == 0)
                        .OrderBy(artist => artist.ArtistId)
                        .Skip((page - 1) * pageSizeArtist)
                        .Take(pageSizeArtist);
                    model.CurrentCategory = 0;
                    model.PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSizeArtist,
                        TotalItems = _repository.Artists.Count()
                    };
                    break;
                case "Зарубежное":
                    model.Artists = _repository.Artists
                        .Where(p => p.LanguageArtistId == 1)
                        .OrderBy(artist => artist.ArtistId) 
                        .Skip((page - 1) * pageSizeArtist)
                        .Take(pageSizeArtist);;
                    model.CurrentCategory = 1;
                    model.PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSizeArtist,
                        TotalItems = _repository.Artists.Count()
                    };
                    break;
                default:
                    model.Artists = _repository.Artists
                       .OrderBy(artist => artist.ArtistId)
                        .Skip((page - 1) * pageSizeArtist)
                        .Take(pageSizeArtist);;
                    model.PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSizeArtist,
                        TotalItems = _repository.Artists.Count()
                    };
                    break;
            }
            return View(model);
        }

        public PartialViewResult Menu(string category = "Все")
        {
            ViewBag.SelectedCategory = category;

            List<string> categories = new List<string>
            {
                "Все",
                LanguageArtist.Русское.ToString(),
                LanguageArtist.Зарубежное.ToString()
            };
            return PartialView(categories);
        }
        public ViewResult Audio(int? artistId)
        {

            AudioViewModels model = new AudioViewModels
            {
                Audios = _repository.Audios
                 .Where(audio => audio.ArtistId == artistId)

                //    .Skip((page - 1) * pageSizeAudio)
                //   .Take(pageSizeAudio),
                //PagingInfo = new PagingInfo
                //{
                // //   CurrentPage = page,
                //    ItemsPerPage = pageSizeAudio,
                //    TotalItems = _repository.Audios.Count()
                //}
            };
            return View(model);
        }

    }
}