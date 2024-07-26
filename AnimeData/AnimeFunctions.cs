using System.Collections.Generic;
using AniModels;

namespace AnimeData
{
    public class AnimeFunctions
    {
        List<Anime> animes;
        SqlDb sqlData;

        public AnimeFunctions()
        {
            animes = new List<Anime>();
            sqlData = new SqlDb();
        }

        public List<Anime> GetAnimes()
        {
            animes = sqlData.GetAnimes();
            return animes;
        }

        public int AddAnime(Anime anime)
        {
            return sqlData.AddAnime(anime.Name, anime.Genre, anime.Rating, anime.Status);
        }

        public int UpdateAnime(Anime anime)
        {
            return sqlData.UpdateAnime(anime.Name, anime.Genre, anime.Rating, anime.Status);
        }

        public int DeleteAnime(Anime anime)
        {
            return sqlData.DeleteAnime(anime.Name);
        }
    }
}
