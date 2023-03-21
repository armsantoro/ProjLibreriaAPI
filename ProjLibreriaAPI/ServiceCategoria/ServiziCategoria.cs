using ProjLibreriaAPI.Model.Categoria;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.ServiceCategoria
{
    public class ServiziCategoria
    {
        public readonly IConfiguration _configuration;
        public ServiziCategoria(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<Categoria> GetCategorie()
        {
            List<Categoria> categorie = new List<Categoria>();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string query = "SELECT* FROM [dbo].[Categoria_Libro]";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Categoria categoria = new Categoria();
                                //categoria.Genere = reader.GetString(0);
                                categorie.Add(new Categoria {
                                    Genere = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }
            return categorie;
        }
    }
}
