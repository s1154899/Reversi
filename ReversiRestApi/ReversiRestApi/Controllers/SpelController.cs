using Microsoft.AspNetCore.Mvc;
using ReversiRestApi.Model;
using ReversiRestApi.Model;


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
            IEnumerable<String> returns = iRepository.GetSpellen().Select(F =>  F.Omschrijving );

            return returns == null ? NotFound() : Ok(returns);

        }


        [Route("api/Spel/waiting")]
        [HttpGet]
        public ActionResult<IEnumerable<Spel>> GetSpelVanSpellenMetWachtendeSpeler()
        {
            IEnumerable<Spel> returns = iRepository.GetSpellen().Where(spel => spel.Speler2Token == null);


            return returns == null ? NotFound() : Ok(returns);

        }

        [Route("api/Spel/Playing")]
        [HttpGet]
        public ActionResult<IEnumerable<Spel>> GetSpellenVanSpeler([FromHeader] string spelerToken)
        {
            IEnumerable<Spel> returns = iRepository.GetSpellen().Where(spel => spel.Speler2Token == spelerToken || spel.Speler1Token == spelerToken);


            return returns == null ? NotFound() : Ok(returns);

        }


        //TODO add bad result
        [Route("api/Spel/Create")]
        [HttpPost]
        public ActionResult PostCreateGame([FromHeader] string speler1Token, [FromHeader] string omschrijving) {

            Spel spel = new Spel() {Speler1Token = speler1Token, Omschrijving = omschrijving };

            iRepository.AddSpel(spel);

            return Ok();

        }

        //TODO add bad result
        [Route("api/Spel/Join/{speltoken}")]
        [HttpPost]
        public ActionResult PostJoinGame(string speltoken,[FromHeader] string speler2Token)
        {

            Spel spel = iRepository.GetSpel(speltoken);
            spel.Speler2Token = speler2Token;

            iRepository.UpdateSpel(speltoken, spel);

            return Ok(spel);

        }

        // GET api/spels
        [Route("api/Spel/{speltoken}")]
        [HttpGet]
        public ActionResult<Spel> GetSpel(string speltoken)
        {
            return Ok(iRepository.GetSpel(speltoken));

        }
        
        // GET api/spels
        [Route("api/Spel/Beurt/{speltoken}")]
        [HttpGet]
        public ActionResult<string> GetBeurt(string speltoken)
        {
            string AandeBeurt = iRepository.GetSpel(speltoken).AandeBeurt;

            return Ok(AandeBeurt);

        }

        // GET api/spels
        [Route("api/Spel/Zet/")]
        [HttpPost]
        public ActionResult<Spel> DoZet([FromBody]string spelToken,[FromHeader] int rijZet,[FromHeader] int kolomZet)
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

