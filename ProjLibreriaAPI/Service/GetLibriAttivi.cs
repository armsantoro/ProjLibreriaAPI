using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjLibreriaAPI.Model.Biblioteca;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.Service
{
    public class GetLibriAttivi
    {
        private readonly IConfiguration _configuration;
        public GetLibriAttivi(IConfiguration configuration) 
        {
           _configuration = configuration;
        }

        public List<LibriAttivi> GetListaAttivi()
        {
            List<LibriAttivi> libriAttivi = new List<LibriAttivi>(); 
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryBiblioteca", "GetLibriAttivi.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LibriAttivi lib = new LibriAttivi();
                                lib.Nome_Libro = reader.GetString(0);
                                lib.Categoria_Libro = reader.GetString(1);
                                lib.Anno_Pubblicazione = reader.GetInt32(2);
                                lib.ISBN = reader.GetString(3);
                                lib.Stato_Libro = reader.GetString(4);
                                lib.Numero_Copie_Presenti = reader.GetInt32(5);
                                libriAttivi.Add(lib);
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
            return libriAttivi;
        }
    }
}
