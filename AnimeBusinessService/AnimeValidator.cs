using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeData;
using AniModels;

namespace AnimeBusinessService
{
    public class AnimeValidator
    {
        AnimeService service = new AnimeService();

        public bool Validate(string animeName)
        {
            bool result = service.GetByName(animeName) != null;
            return result;
        }

        public bool ValidateGenre(string animeGenre)
        {
            bool result = service.GetByGenre(animeGenre) != null;
            return result;
        }
    }
}
