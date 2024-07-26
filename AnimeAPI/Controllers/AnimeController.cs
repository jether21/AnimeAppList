using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using AnimeBusinessService;
using AniModels;

namespace AnimeAPI.Controllers
{
    [ApiController]
    [Route("api/anime")]
    public class AnimeController : ControllerBase
    {
        AnimeService _animeService;
        AnimeManager _animeManager;

        public AnimeController()
        {
            _animeService = new AnimeService();
            _animeManager = new AnimeManager();
        }

        [HttpGet]
        public IEnumerable<AnimeAPI.Anime> GetAnimes()
        {
            var animes = _animeService.GetAllAnimes();

            List<AnimeAPI.Anime> animeList = new List<AnimeAPI.Anime>();

            foreach (var anime in animes)
            {
                animeList.Add(new AnimeAPI.Anime { Name = anime.Name, Genre = anime.Genre, Rating = anime.Rating, Status = anime.Status });
            }
            return animeList;
        }

        [HttpPost]
        public JsonResult AddAnime(AnimeAPI.Anime request)
        {
            var result = _animeManager.CreateAnime(request.Name, request.Genre, request.Rating, request.Status);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateAnime(AnimeAPI.Anime request)
        {
            var result = _animeManager.UpdateAnime(request.Name, request.Genre, request.Rating, request.Status);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteAnime(AnimeAPI.Anime request)
        {
            var anime = new AniModels.Anime
            {
                Name = request.Name
            };
            var result = _animeManager.DeleteAnime(anime);

            return new JsonResult(result);
        }
    }
}
