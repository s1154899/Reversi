using Microsoft.AspNetCore.Mvc;
using ReversieISpelImplementatie.Model;
using ReversiRestApi.Model;

namespace ReversiRestApi.Controllers
{
    [Route("api/Spel")]
    [ApiController]
    public class SpelController : ControllerBase
    {
        private readonly ISpelRepository iRepository;

        public SpelController(ISpelRepository repository)
        {
            iRepository = repository;
        }

        
        // GET api/spellen
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            IEnumerable<String> returns = iRepository.GetSpellen().Select(F => F.Omschrijving);

            return returns == null ? NotFound() : Ok(returns);

        }
        
        
        //TODO add bad result

        [HttpPost]
        public ActionResult PostCreateGame([FromHeader] string speler1Token, [FromHeader] string omschrijving) {

            Spel spel = new Spel() {Speler1Token = speler1Token, Omschrijving = omschrijving };

            iRepository.AddSpel(spel);

            return Ok();

        }
        
        
        // GET api/spels
        [Route("{token}/spel")]
        [HttpPost]
        public ActionResult<Spel> GetSpel(string token)
        {
             SendableSpel returns = new SendableSpel(iRepository.GetSpel(token));

            return Ok(returns);

        }
        

    }


}

