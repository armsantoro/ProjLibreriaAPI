using Microsoft.AspNetCore.Mvc;
using ProjLibreriaAPI.Model.Biblioteca;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class UpdateLibroByID
    {
        private readonly IConfiguration _configuration;
        public UpdateLibroByID(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LibroUpdated UpdateByID(string id, string nomeLibro, string catLibro, int annoPub, string isbn, string statoLib, int numCopie)
        {
            int isCreated = 0;
            LibroUpdated libroUpdated = new LibroUpdated();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryBiblioteca", "UpdateLibroByID.sql");
                string query = File.ReadAllText(queryPath);

                GetLibroByID libroByID = new GetLibroByID(_configuration);
                libroUpdated.LibroVecchio = libroByID.GetLibro(id);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NewNome", nomeLibro);
                        cmd.Parameters.AddWithValue("@NewCategoria", catLibro);
                        cmd.Parameters.AddWithValue("@NewAnnoPubblicazione", annoPub);
                        cmd.Parameters.AddWithValue("NewISBN", isbn);
                        cmd.Parameters.AddWithValue("@NewStatoLibro", statoLib);
                        cmd.Parameters.AddWithValue("@NewCopiePresenti", numCopie);
                        isCreated = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            if (isCreated > 0)
                libroUpdated.NuovoUpdate = "Libro aggiornato correttamente!";
            else
                libroUpdated.NuovoUpdate = "Errore nell'aggiornamento del libro!";
            return libroUpdated;
        }
    }
}
