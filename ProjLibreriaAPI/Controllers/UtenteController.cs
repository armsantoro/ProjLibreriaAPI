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
    }
}
