using Microsoft.AspNetCore.Mvc;
using ReversieISpelImplementatie.Model;
using ReversiRestApi.Model;
using Kleur = ReversiRestApi.Model.Kleur;

namespace ReversiRestApi.Controllers
{
    
    [ApiController]
    public class SpelController : ControllerBase
    {
        private readonly ISpelRepository iRepository;

        public SpelController(ISpelRepository repository)
        {
            iRepository = repository;
        }


        // GET api/spellen
        [Route("api/Spel")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            IEnumerable<String> returns = iRepository.GetSpellen().Select(F => F.Omschrijving);

            return returns == null ? NotFound() : Ok(returns);

        }


        //TODO add bad result
        [Route("api/Spel")]
        [HttpPost]
        public ActionResult PostCreateGame([FromHeader] string speler1Token, [FromHeader] string omschrijving) {

            Spel spel = new Spel() {Speler1Token = speler1Token, Omschrijving = omschrijving };

            iRepository.AddSpel(spel);

            return Ok();

        }


        // GET api/spels
        [Route("api/Spel/{speltoken}")]
        [HttpGet]
        public ActionResult<Spel> GetSpel(string speltoken)
        {
            SendableSpel returns = new SendableSpel(iRepository.GetSpel(speltoken));

            return Ok(returns);

        }
        
        // GET api/spels
        [Route("api/Spel/Beurt/{speltoken}")]
        [HttpGet]
        public ActionResult<Spel> GetBeurt(string speltoken)
        {
            Kleur AandeBeurt = (Kleur)iRepository.GetSpel(speltoken).AandeBeurt;

            return Ok(AandeBeurt);

        }

        // GET api/spels
        [Route("api/Spel/Zet/{speltoken}")]
        [HttpPost]
        public ActionResult<Spel> DoZet(string spelToken,[FromHeader] int rijZet,[FromHeader] int kolomZet)
        {
            try
            {
                iRepository.GetSpel(spelToken).DoeZet(rijZet, kolomZet);

                return Ok();
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

    }


}

