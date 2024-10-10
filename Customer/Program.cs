using AnimeBusinessService;
using AniModels;
using System;

namespace Customer
{
    public class Program
    {
        static void Main(string[] args)
        {
            AnimeManager animeManager = new AnimeManager();
            AniService emailService = new AniService();

            while (true)
            {
                Console.WriteLine("Customer Management System");
                Console.WriteLine("1. View your list");
                Console.WriteLine("2. Add to your list");
                Console.WriteLine("3. Update list");
                Console.WriteLine("4. Delete list");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ViewAllAnime(animeManager);
                        break;

                    case 2:
                        AddAnime(animeManager, emailService);
                        break;

                    case 3:
                        UpdateAnime(animeManager, emailService);
                        break;

                    case 4:
                        DeleteAnime(animeManager, emailService);
                        break;


                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }

        private static void ViewAllAnime(AnimeManager animeManager)
        {
            var animeList = animeManager.GetAllAnimes();
            Console.WriteLine("Anime List:");
            foreach (var anime in animeList)
            {
                Console.WriteLine($"Name: {anime.Name}, Genre: {anime.Genre}, Rating: {anime.Rating}, Status: {anime.Status}");
            }
        }

        private static void AddAnime(AnimeManager animeManager, AniService emailService)
        {
            Console.Write("Enter anime name: ");
            string name = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter rating: ");
            string rating = Console.ReadLine();
            Console.Write("Enter status: ");
            string status = Console.ReadLine();

            var success = animeManager.CreateAnime(name, genre, rating, status);
            Console.WriteLine(success ? "Anime added successfully." : "Failed to add anime.");

            emailService.SendEmail("Anime added ", " an item has been added to list :) ");
        }

        private static void UpdateAnime(AnimeManager animeManager, AniService emailService)
        {
            Console.Write("Enter the name of the anime to update: ");
            string name = Console.ReadLine();

            Console.Write("Enter new genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter new rating: ");
            string rating = Console.ReadLine();
            Console.Write("Enter new status: ");
            string status = Console.ReadLine();

            var success = animeManager.UpdateAnime(name, genre, rating, status);
            Console.WriteLine(success ? "Anime updated successfully." : "Failed to update anime.");

            emailService.SendEmail("list updated ", "your list is updated? <333");
        }

        private static void DeleteAnime(AnimeManager animeManager, AniService emailService)
        {
            Console.Write("Enter the name of the anime to delete: ");
            string name = Console.ReadLine();

            var anime = animeManager.GetByName(name);
            if (anime != null)
            {
                var success = animeManager.DeleteAnime(anime);
                Console.WriteLine(success ? "Anime deleted successfully." : "Failed to delete anime.");

                emailService.SendEmail("Anime deleted ", " an item has been deleted to your list :( ");
            }
            else
            {
                Console.WriteLine("Anime not found.");
            }
        }

      
    }
}
