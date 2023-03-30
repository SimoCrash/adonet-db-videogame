using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        string connStr;

        public VideogameManager(string connStr)
        {
            this.connStr = connStr;
        }

        public List<Videogame> GetVideogamesByNameLike(string likeString)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();

                var query = "SELECT id, name, release_date, software_house_id" +
                    " FROM videogames " +
                    $"WHERE name LIKE @NameLike " +
                    "ORDER BY name";

                using var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@NameLike", $"%{likeString}%");

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(idIdx);

                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(nameIdx);

                    var release_dateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(release_dateIdx);

                    var softWareIdx = reader.GetOrdinal("software_house_id");
                    var softWare = reader.GetInt64(softWareIdx);

                    var v = new Videogame(id, name, release_date, softWare);
                    videogames.Add(v);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return videogames;
        }

        public List<Videogame> GetVideogameById()
        {
            
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();

                var tran = conn.BeginTransaction();

                var query = "SELECT id, name " +
                "FROM videogames " +
                "WHERE id = @numId";

                using var command = new SqlCommand(query, conn);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(idIdx);

                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(nameIdx);

                    var release_dateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(release_dateIdx);

                    var softWareIdx = reader.GetOrdinal("software_house_id");
                    var softWare = reader.GetInt64(softWareIdx);

                    var v = new Videogame(id, name, release_date, softWare);
                    videogames.Add(v);
                }
                tran.Commit();
            }
            catch (Exception ex) 
            {
                Console.Write(ex.Message);
                tran.Rollback();
            }    
            
            return videogames;
        }
    }
}
