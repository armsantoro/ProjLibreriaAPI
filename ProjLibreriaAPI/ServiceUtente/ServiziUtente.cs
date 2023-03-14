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

        public Utente GetByIDLibro(string idLib)
        {
            Utente utente = new Utente();
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryUtente", "GetUtenteByIDLibro.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_Libro", idLib);
                        using (SqlDataReader reader = cmd.ExecuteReader())
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

        #region TestMetodoAlternativoGetbyID
        //Metodo che utilizza una query direttamente dal codice senza fare logica sul db. Tutto viene gestito lato c#.  
        //Fare particolare attenzione alle conversioni
        //public Utente GetUtenteByIDAlternative(string id)
        //{
        //    Utente utente = new Utente();
        //    try
        //    {
        //        string connectionString = _configuration.GetConnectionString("localBibliodb");

        //        string query = "SELECT* FROM [dbo].[Utenti_Tesserati]";
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            using (SqlCommand cmd = new SqlCommand(query, connection))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {

        //                    while (reader.Read())
        //                    {
        //                       // Guid guidString = Guid.Parse(reader.GetGuid(0));
        //                        if (reader.GetGuid(0).ToString("D") == id.ToLower())
        //                        {
        //                            utente.Nome_Utente = reader.GetString(1);
        //                            utente.Cognome_Utente = reader.GetString(2);
        //                            utente.Indirizzo = reader.GetString(3);
        //                            utente.Libro = reader.GetGuid(4).ToString("D");
        //                        }

        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return utente;
        //}
        #endregion

        public int UpdateUtenteByID(string id, string nome, string cognome, string indirizzo, string ISBN, bool statoRecord)
        {
            int isUpdated = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryUtente", "UpdateUtenteByID.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NewNome", nome);
                        cmd.Parameters.AddWithValue("@NewCognome", cognome);
                        cmd.Parameters.AddWithValue("@NewIndirizzo", indirizzo);
                        cmd.Parameters.AddWithValue("@NewISBN", ISBN);
                        cmd.Parameters.AddWithValue("@NewStatoRecord", statoRecord);
                        isUpdated = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return isUpdated;
        }

        public int InsertNewUtente(string nome, string cognome, string indirizzo, string isbn, bool statoRecord)
        {
            int isCreated = 0;
            try
            {
                string connectionString = _configuration.GetConnectionString("localBibliodb");
                string queryPath = Path.Combine(Environment.CurrentDirectory, "QueryUtente", "InsertUtente.sql");
                string query = File.ReadAllText(queryPath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NewNome", nome);
                        cmd.Parameters.AddWithValue("@NewCognome", cognome);
                        cmd.Parameters.AddWithValue("@NewIndirizzo", indirizzo);
                        cmd.Parameters.AddWithValue("@NewISBN", isbn);
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
