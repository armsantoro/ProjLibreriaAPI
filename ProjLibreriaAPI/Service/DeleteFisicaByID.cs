using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class DeleteFisicaByID
    {
        private readonly IConfiguration _configuration;
        public DeleteFisicaByID(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int DeleteFisica(string id)
        {
            int statoRecord = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryBiblioteca", "DeleteFisicaByID.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        statoRecord = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return statoRecord;
        }
    }
}
