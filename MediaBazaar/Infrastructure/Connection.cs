using Microsoft.Data.SqlClient;
namespace Infrastructure
{
    internal static class Connection
    {
        internal static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi499768_i499768;User Id=dbi499768_i499768;Password=originalDB01;Encrypt=False;");
                conn.Open();
                return conn;
            }
            catch { throw new Exception("Connection Unavailable"); }
        }
    }
}