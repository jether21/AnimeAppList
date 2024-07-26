using AnimeBusinessService;
using AniModels;

namespace Customer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimeService animeService = new AnimeService();

            var animeList = animeService.GetAllAnimes();

            foreach (var item in animeList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Genre);
                Console.WriteLine(item.Rating);
                Console.WriteLine(item.Status);
            }
        }
    }
}
