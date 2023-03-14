using Microsoft.Extensions.Configuration;
using ProjLibreriaAPI.Model.Biblioteca;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class InsertListLibri
    {
        public readonly IConfiguration _configuration;
        public InsertListLibri(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int InsertListaLibri(List<LibriAttivi> libriAttivi)
        {
            int isCreated = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryBiblioteca", "InsertLibro.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction tran = connection.BeginTransaction();
                    try
                    {
                        foreach (LibriAttivi libro in libriAttivi)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                isCreated = 0;
                                cmd.Transaction = tran;
                                cmd.Parameters.AddWithValue("@NewNome", libro.Nome_Libro);
                                cmd.Parameters.AddWithValue("@NewCategoria", libro.Categoria_Libro);
                                cmd.Parameters.AddWithValue("@NewAnnoPubblicazione", libro.Anno_Pubblicazione);
                                cmd.Parameters.AddWithValue("NewISBN", libro.ISBN);
                                cmd.Parameters.AddWithValue("@NewStatoLibro", libro.Stato_Libro);
                                cmd.Parameters.AddWithValue("@NewCopiePresenti", libro.Numero_Copie_Presenti);
                                cmd.Parameters.AddWithValue("@NewStatoRecord", 1);
                                isCreated = cmd.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Debug.Write(ex.Message);
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
