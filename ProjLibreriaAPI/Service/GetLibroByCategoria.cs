using ProjLibreriaAPI.Model.Biblioteca;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class GetLibroByCategoria
    {
        private readonly IConfiguration _configuration;
        public GetLibroByCategoria(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<LibriAttivi> GetLibro(string categoria)
        {
            List<LibriAttivi> libri = new List<LibriAttivi>();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryBiblioteca", "GetLibroByCategoria.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Categoria", categoria);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LibriAttivi libroResult = new LibriAttivi();
                                libroResult.Nome_Libro = reader.GetString(0);
                                libroResult.Categoria_Libro = reader.GetString(1);
                                libroResult.Anno_Pubblicazione = reader.GetInt32(2);
                                libroResult.ISBN = reader.GetString(3);
                                libroResult.Stato_Libro = reader.GetString(4);
                                libroResult.Numero_Copie_Presenti = reader.GetInt32(5);
                                libri.Add(libroResult);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return libri;
        }
    }
}
