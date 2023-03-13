using ProjLibreriaAPI.Model.Biblioteca;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class GetLibroByID
    {
        private readonly IConfiguration _configuration;
        public GetLibroByID(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LibriAttivi GetLibro(string id)
        {
            LibriAttivi libroResult = new LibriAttivi();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "Query", "GetLibroByID.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                libroResult.Nome_Libro = reader.GetString(0);
                                libroResult.Categoria_Libro = reader.GetString(1);
                                libroResult.Anno_Pubblicazione = reader.GetInt32(2);
                                libroResult.ISBN = reader.GetString(3);
                                libroResult.Stato_Libro = reader.GetString(4);
                                libroResult.Numero_Copie_Presenti = reader.GetInt32(5);
                            }
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                throw;
            }
            return libroResult;
        }
    }
}
