using Microsoft.AspNetCore.Mvc;
using ProjLibreriaAPI.Model.Utente;
using ProjLibreriaAPI.ServiceUtente;

namespace ProjLibreriaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : Controller
    {
        
        private readonly IConfiguration _configuration;
        public UtenteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("GetUtentiAttivi")]
        public IEnumerable<Utente> GetUtentiAttivi() 
        {
            ServiziUtente serviziUtente = new ServiziUtente(_configuration);
            return serviziUtente.GetUtentiAttivi();
        }

        [HttpGet("GetUtenteByID")]
        public Utente GetUtenteByID(string id) 
        {
            ServiziUtente serviziUtente = new ServiziUtente(_configuration);
            return serviziUtente.GetByID(id);
        }

        [HttpGet("GetUtenteByIDLibro")]
        public Utente GetUtenteByIDLibro(string idLib)
        {
            ServiziUtente serviziUtente = new ServiziUtente(_configuration);
            return serviziUtente.GetByIDLibro(idLib);
        }

        #region controller GetUtenteByIDAlternative
        //[HttpGet("GetUtenteByIDAlternative")]
        //public Utente GetUtenteByIDAlternative(string id)
        //{
        //    ServiziUtente serviziUtente = new ServiziUtente(_configuration);
        //    return serviziUtente.GetUtenteByIDAlternative(id);
        //}
        #endregion

        [HttpPost("UpdateUtenteByID")]
        public IActionResult UpdateUtenteByID(string id, string nome, string cognome, string indirizzo, string ISBN, bool statoRecord)
        {
            ServiziUtente serviziUtente = new ServiziUtente(_configuration);
            if (serviziUtente.UpdateUtenteByID(id, nome, cognome, indirizzo, ISBN, statoRecord) > 0)
                return Ok(StatusCodes.Status202Accepted);
            else
                return BadRequest();         
        }

        [HttpPut("InsertUtente")]
        public IActionResult InsertUtente(string nome, string cognome, string indirizzo, string isbn, bool statoRecord)
        {
            ServiziUtente serviziUtente = new ServiziUtente(_configuration);
            if(serviziUtente.InsertNewUtente(nome, cognome, indirizzo, isbn, statoRecord) > 0)
                return Ok(StatusCodes.Status201Created);
            else 
                return BadRequest();
        }
    }
}
