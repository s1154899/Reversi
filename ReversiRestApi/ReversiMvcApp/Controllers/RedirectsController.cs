using Microsoft.AspNetCore.Mvc;
using ReversiMvcApp.Models;

namespace ReversiMvcApp.Controllers
{
    public class RedirectsController : Controller
    {
        public IActionResult Index()
        {
            return Ok("test");
        }

        [Route("redirect/dozet/{speler}/{spel}/{rij}/{kolom}")]
        public IActionResult DoZet(string speler, string spel, string rij, string kolom) {

            return Ok(APIReversi.PostDoZet(spel,rij,kolom,speler).Result);
        }

        [Route("redirect/GetSpel/{spel}")]
        public IActionResult GetSpel( string spel)
        {

            return Ok(APIReversi.GetSpel(spel).Result);
        }
    }
}
