using adonet_db_videogame;
using System.Data.SqlClient;

var connStr = "Data Source=localhost;Initial Catalog=db-videogames-query;Integrated Security=True";

using var conn = new SqlConnection(connStr);

var videogames = new List<Videogame>();


try
{
    conn.Open();
    var query = "SELECT id, name, release_date, software_house_id description FROM videogames";
    using var command = new SqlCommand(query, conn);
    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        var id = reader.GetInt64(0);
        var name = reader.GetString(1);
        var realease_date = reader.GetDateTime(2);
        var softwareHouse = reader.GetInt64(3);

        var v = new Videogame(id, name, realease_date, softwareHouse);
        videogames.Add(v);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
foreach (var videogame in videogames) Console.WriteLine(videogame);
Console.WriteLine("Totale: "  + videogames.Count());
