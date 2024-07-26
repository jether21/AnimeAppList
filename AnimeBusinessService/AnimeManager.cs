using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AnimeData;
using AniModels;

namespace AnimeBusinessService
{
    public class AnimeManager
    {
        AnimeValidator validator = new AnimeValidator();
        AnimeFunctions functions = new AnimeFunctions();

        public bool CreateAnime(Anime anime)
        {
            bool result = false;

            if (validator.Validate(anime.Name))
            {
                result = functions.AddAnime(anime) > 0;
            }
            return result;
        }

        public bool CreateAnime(string name, string genre, string rating, string status)
        {
            Anime anime = new Anime { Name = name, Genre = genre, Rating = rating, Status = status };

            return CreateAnime(anime);
        }

        public bool UpdateAnime(Anime anime)
        {
            bool result = false;

            if (validator.Validate(anime.Name))
            {
                result = functions.UpdateAnime(anime) > 0;
            }
            return result;
        }

        public bool UpdateAnime(string name, string genre, string rating, string status)
        {
            Anime anime = new Anime { Name = name, Genre = genre, Rating = rating, Status = status };

            return UpdateAnime(anime);
        }

        public bool DeleteAnime(Anime anime)
        {
            bool result = false;

            if (validator.Validate(anime.Name))
            {
                result = functions.DeleteAnime(anime) > 0;
            }
            return result;
        }
    }
}
