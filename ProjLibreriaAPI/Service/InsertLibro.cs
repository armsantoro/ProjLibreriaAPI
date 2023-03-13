using Microsoft.Data.SqlClient;
using ProjLibreriaAPI.Model.Biblioteca;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class InsertLibro
    {
        private readonly IConfiguration _configuration;
        public InsertLibro(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int InsertNewLibro(string nomeLibro, string catLibro, int annoPub, string isbn, string statoLib, int numCopie, bool statoRecord)
        {
            int isCreated = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "Query", "InsertLibro.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NewNome", nomeLibro);
                        cmd.Parameters.AddWithValue("@NewCategoria", catLibro);
                        cmd.Parameters.AddWithValue("@NewAnnoPubblicazione", annoPub);
                        cmd.Parameters.AddWithValue("NewISBN", isbn);
                        cmd.Parameters.AddWithValue("@NewStatoLibro", statoLib);
                        cmd.Parameters.AddWithValue("@NewCopiePresenti", numCopie);
                        cmd.Parameters.AddWithValue("@NewStatoRecord", statoRecord);
                        isCreated = cmd.ExecuteNonQuery();
                    }
                }
            }
            
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return isCreated;
        }
    }
}
