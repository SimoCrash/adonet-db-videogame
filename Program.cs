using adonet_db_videogame;
using System.Data.SqlClient;

var connStr = "Data Source=localhost;Initial Catalog=db-videogames-query;Integrated Security=True";

var repo = new VideogameManager(connStr);

var videogames = repo.GetVideogamesByNameLike("au");

foreach (var videogame in videogames) Console.WriteLine(videogame);
Console.WriteLine("Totale: "  + videogames.Count());
