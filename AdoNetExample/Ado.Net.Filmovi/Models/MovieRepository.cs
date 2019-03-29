using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ado.Net.Filmovi.Models
{
    public class MovieRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MoviesAdoNetDB"].ConnectionString;
       
        public Movie Create(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateMovie", conn))
                {
                    //cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = "CreateMovie";

                    //cmd.Parameters.AddWithValue("@MovieId", movie.MovieId);
                    cmd.Parameters.AddWithValue("@Title", movie.Title);
                    cmd.Parameters.AddWithValue("@Director", movie.Director);
                    cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);

                    conn.Open();

                   int MovieId = (int)cmd.ExecuteScalar();

                }
            }
            return movie;
        }

        public void Update(Movie movie)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("EditMovie", conn))
                {
                   // cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = "EditMovie";

                    cmd.Parameters.AddWithValue("@MovieId", movie.MovieId);
                    cmd.Parameters.AddWithValue("@Title", movie.Title);
                    cmd.Parameters.AddWithValue("@Director", movie.Director);
                    cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public Movie getOne(int id)
        {
            Movie movie = new Movie();

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = "SELECT * FROM Movies WHERE MovieId = @MovieId";
                    cmd.Parameters.AddWithValue("@MovieId", id);

                    conn.Open();

                    using(SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            movie.MovieId = (int)dr["MovieId"];
                            movie.Title = dr["Title"].ToString();
                            movie.Director = dr["Director"].ToString();
                            movie.ReleaseDate = (DateTime)dr["ReleaseDate"];

                        }
                    }
                }
            }

            return movie;
        }

        public List<Movie> getAll()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Movies ORDER BY Title";

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            List<Movie> movies = new List<Movie>();

            while (dr.Read())
            {
                Movie movie = new Movie();
                movie.MovieId = (int)dr["MovieId"];
                movie.Title = dr["Title"].ToString();
                movie.Director = dr["Director"].ToString();
                movie.ReleaseDate =(DateTime) dr["ReleaseDate"];
                movies.Add(movie);
            }

            return movies;
        }

        public void Delete(int id)
        {
          

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
              
                using(SqlCommand cmd = new SqlCommand("DeleteMovie", conn))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovieId", id);

                    conn.Open();
                    int movieId = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}