using AniModels;
using AnimeData;

namespace AnimeBusinessService
{
    public class AnimeService
    {
        public List<Anime> GetAllAnimes()
        {
            AnimeFunctions functions = new AnimeFunctions();
            return functions.GetAnimes();
        }

        public Anime GetByName(string animeName)
        {
            Anime foundAnime = new Anime();

            foreach (var anime in GetAllAnimes())
            {
                if (anime.Name == animeName)
                {
                    foundAnime = anime;
                }
            }
            return foundAnime;
        }

        public Anime GetByGenre(string animeGenre)
        {
            Anime foundAnime = new Anime();

            foreach (var anime in GetAllAnimes())
            {
                if (anime.Genre == animeGenre)
                {
                    foundAnime = anime;
                }
            }
            return foundAnime;
        }
    }
}
