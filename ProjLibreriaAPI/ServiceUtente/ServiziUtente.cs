using ProjLibreriaAPI.Model.Utente;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjLibreriaAPI.ServiceUtente
{
    public class ServiziUtente
    {
        private readonly IConfiguration _configuration;
        public ServiziUtente (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Utente> GetUtentiAttivi()
        {
            List<Utente> utenti = new List<Utente>();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryUtente", "GetUtentiAttivi.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Utente utente = new Utente();
                                utente.Nome_Utente = reader.GetString(0);
                                utente.Cognome_Utente = reader.GetString(1);
                                utente.Indirizzo = reader.GetString(2);
                                utente.Libro = reader.GetString(3);
                                utenti.Add(utente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);

            }
            return utenti;
        }

        public Utente GetByID(string id)
        {
            Utente utente = new Utente();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryUtente", "GetUtenteByID.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                utente.Nome_Utente = reader.GetString(0);
                                utente.Cognome_Utente = reader.GetString(1);
                                utente.Indirizzo = reader.GetString(2);
                                utente.Libro = reader.GetString(3);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
             
            }
            return utente;
        }
    }
}
