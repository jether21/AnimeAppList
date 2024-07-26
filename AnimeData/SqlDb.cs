using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AniModels;

namespace AnimeData
{
    public class SqlDb
    {
        string connection = "Server = tcp:20.2.250.60,1433; Database =Jether; User Id =sa; Password =bsit2!";
        SqlConnection sqlConnection;

        public SqlDb()
        {
            sqlConnection = new SqlConnection(connection);
        }

        public List<Anime> GetAnimes()
        {
            string SELECT = "SELECT * FROM aniList";

            SqlCommand selcom = new SqlCommand(SELECT, sqlConnection);
            sqlConnection.Open();

            List<Anime> animeList = new List<Anime>();
            SqlDataReader reader = selcom.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string genre = reader["Genre"].ToString();
                string rating = reader["Rating"].ToString();
                string status = reader["Status"].ToString();

                Anime anime = new Anime
                {
                    Name = name,
                    Genre = genre,
                    Rating = rating,
                    Status = status
                };

                animeList.Add(anime);
            }

            sqlConnection.Close();
            return animeList;
        }

        public int AddAnime(string name, string genre, string rating, string status)
        {
            int success;

            string INSERT = "INSERT INTO aniList VALUES(@Name, @Genre, @Rating, @Status)";

            SqlCommand incom = new SqlCommand(INSERT, sqlConnection);

            incom.Parameters.AddWithValue("@Name", name);
            incom.Parameters.AddWithValue("@Genre", genre);
            incom.Parameters.AddWithValue("@Rating", rating);
            incom.Parameters.AddWithValue("@Status", status);

            sqlConnection.Open();
            success = incom.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int UpdateAnime(string name, string genre, string rating, string status)
        {
            int success;

            string UPDATE = "UPDATE aniList SET Genre = @Genre, Rating = @Rating, Status = @Status WHERE Name = @Name";

            SqlCommand upcom = new SqlCommand(UPDATE, sqlConnection);

            upcom.Parameters.AddWithValue("@Genre", genre);
            upcom.Parameters.AddWithValue("@Rating", rating);
            upcom.Parameters.AddWithValue("@Status", status);
            upcom.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            success = upcom.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int DeleteAnime(string name)
        {
            int success;

            string DELETE = "DELETE FROM aniList WHERE Name = @Name";

            SqlCommand delcom = new SqlCommand(DELETE, sqlConnection);
            delcom.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            success = delcom.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }
    }
}
