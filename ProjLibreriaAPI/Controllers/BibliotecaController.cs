using Microsoft.AspNetCore.Mvc;
using ProjLibreriaAPI.Model.Biblioteca;
using ProjLibreriaAPI.Service;

namespace ProjLibreriaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotecaController : Controller
    {
        private readonly IConfiguration _configuration;
        public BibliotecaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetLibriAttivi")]
        public IEnumerable<LibriAttivi> GetAttivi()
        {
            GetLibriAttivi libriAttivi = new GetLibriAttivi(_configuration);
            return libriAttivi.GetListaAttivi();
        }

        [HttpGet("GetLibroByID")]
        public LibriAttivi GetLibroByID(string id)
        {
            GetLibroByID libroID = new GetLibroByID(_configuration);
            return libroID.GetLibro(id);
        }

        [HttpGet("GetLibroByCategoria")]
        public List<LibriAttivi> GetLibroByCategoria(string categoria)
        {
            GetLibroByCategoria libroCat = new GetLibroByCategoria(_configuration);
            return libroCat.GetLibro(categoria);
        }

        [HttpPost("UpdateLibroById")]
        public LibroUpdated UpdateLibroByID(string id, string nomeLibro, string catLibro, int annoPub, string isbn, string statoLib, int numCopie)
        {
            UpdateLibroByID updateLib = new UpdateLibroByID(_configuration);
            return updateLib.UpdateByID(id, nomeLibro, catLibro, annoPub, isbn, statoLib, numCopie);
        }

        [HttpPut("InsertLibro")]
        public IActionResult InsertLibro(string nomeLibro, string catLibro, int annoPub, string isbn, string statoLib, int numCopie, bool statoRecord)
        {
            InsertLibro insertLibro = new InsertLibro(_configuration);
            if (insertLibro.InsertNewLibro(nomeLibro, catLibro, annoPub, isbn, statoLib, numCopie, statoRecord) > 0)
                return Ok(StatusCodes.Status200OK);
            else 
                return BadRequest();
        }

        [HttpDelete("DeleteFisicaByID")]
        public IActionResult DeleteFisicaByID(string id) 
        {
            DeleteFisicaByID deleteFisicaByID = new DeleteFisicaByID(_configuration);
            if (deleteFisicaByID.DeleteFisica(id) > 0)
                return Ok(StatusCodes.Status202Accepted);
            else 
                return BadRequest(StatusCodes.Status404NotFound);
        }

        [HttpPut("InsertListLibri")]
        public IActionResult InsertListLibri(List<LibriAttivi> libriAttivi)
        {
            InsertListLibri insertLibri = new InsertListLibri(_configuration);
            if(insertLibri.InsertListaLibri(libriAttivi)>0)
                return Ok(StatusCodes.Status200OK);
            else
                return BadRequest();
        }
    }
}
