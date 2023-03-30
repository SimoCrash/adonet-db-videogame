using System.Data.SqlClient;

var connStr = "Data Source=localhost;Initial Catalog=db-videogames-query;Integrated Security=True";

using var conn = new SqlConnection(connStr);

try
{
    conn.Open();
}
catch
{

}
