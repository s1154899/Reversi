using Microsoft.AspNetCore.Mvc;
using ReversiMvcApp.Models;
using ReversiRestApi.Model;

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
            try
            {
                return Ok(APIReversi.GetSpel(spel).Result);
            }
            catch (Exception ex) { 
            return Ok(new Spel());
            }
        }

        [Route("redirect/DoPas/{spel}/{speler}")]
        public IActionResult GetDoPas(string spel,string speler)
        {

            return Ok(APIReversi.PostDoPas(spel,speler).Result);
        }

        [Route("redirect/Surrender/{spel}/{speler}")]
        public IActionResult GetSurrender(string spel, string speler)
        {

            return Ok(APIReversi.PostSurrender(spel, speler).Result);
        }


        [Route("redirect/Afgelopen/{spel}")]
        public IActionResult GetIsAfgelopen(string spel)
        {

            return Ok(APIReversi.IsAfgelopen(spel).Result);
        }
    }
}
