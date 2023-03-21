using Microsoft.AspNetCore.Mvc;
using ProjLibreriaAPI.Model.Categoria;
using ProjLibreriaAPI.ServiceCategoria;

namespace ProjLibreriaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IConfiguration _configuration;
        public CategoriaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetCategoria")]
        public List<Categoria> GetCategorie()
        {
            ServiziCategoria serviziCategoria = new ServiziCategoria(_configuration);
            return serviziCategoria.GetCategorie();
        }
    }
}
