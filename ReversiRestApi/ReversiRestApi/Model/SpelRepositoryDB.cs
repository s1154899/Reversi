using ReversiRestApi.Model;
using ReversiRestApi.Data;
using ReversiRestApi.Model;
using System.Linq;

namespace ReversiRestApi.Model
{
    public class SpelRepositoryDB : ISpelRepository
    {
        private readonly ReversiContext _context;

        public SpelRepositoryDB(ReversiContext context) { 
        
        _context = context;
        }

        public void AddSpel(Spel spel)
        {
          SpelData s = new SpelData() {Token = spel.Token, Speler1Token = spel.Speler1Token, Speler2Token = spel.Speler2Token, Omschrijving = spel.Omschrijving, AandeBeurt = spel.AandeBeurt.ToString() };
            _context.Spellen.Add(s);
            Bord b = new Bord() { Token = spel.Token, BespeeldBord = String.Join(",",spel.Bord), Spel = s};
            _context.Bord.Add(b);
            _context.SaveChanges();
        }

        public Spel GetSpel(string spelToken)
        {
            List<SpelData> spellen = _context.Spellen.Where(spel => spel.Token == spelToken).ToList();
           List<Bord> bord = _context.Bord.Where(spel => spel.Token == spelToken).ToList();
            Spel spel;
            try
            {
                spel = new Spel() { Speler1Token = spellen[0].Speler1Token, Speler2Token = spellen[0].Speler2Token, Omschrijving = spellen[0].Omschrijving, Token = spellen[0].Token, AandeBeurt = spellen[0].AandeBeurt };
                spel.Bord = bord[0].BespeeldBord.Split(',');
            }
            catch (Exception ex) {
                spel = new Spel();
            }

            

            return spel;

        }

        public List<Spel> GetSpellen()
        {
            IEnumerable<ISpelData> spellen = _context.Spellen.ToList();
            List<Spel> spellenList = new List<Spel>();
            foreach (ISpelData spel in spellen) {
                List<Bord> bord = _context.Bord.Where(spel => spel.Token == spel.Token).ToList();
                spellenList.Add(new Spel() { Speler1Token = spel.Speler1Token , Speler2Token = spel.Speler2Token ,Omschrijving = spel.Omschrijving, Token = spel.Token, Bord = bord[0].BespeeldBord.Split(',') });
            }
            return (List<Spel>)spellenList;

        }

        public void RemoveSpel(string spelToken)
        {
            _context.Spellen.Remove(_context.Spellen.Where(spel => spel.Token == spelToken).FirstOrDefault());
            _context.SaveChanges();
        }

        public void UpdateSpel(string spelToken, Spel spel)
        {
            RemoveSpel(spelToken);
            AddSpel(spel);

        }


    }
        
}
