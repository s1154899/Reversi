using ReversieISpelImplementatie.Model;

namespace ReversiRestApi.Model
{
    public enum Kleur { Geen, Wit, Zwart };
    public class SendableSpel
    {

        public int bordOmvang;
        public int[,] richting;

        public SendableSpel(Spel spel) { 
            bordOmvang = spel.bordOmvang; 
            richting = spel.richting; 
            ID = spel.ID;
            Omschrijving = spel.Omschrijving;
            Token = spel.Token;
            Speler1Token = spel.Speler1Token;
            Speler2Token = spel.Speler2Token;

            Bord = new string[(8*8)];
            int i = 0;
            foreach (Kleur kleur in spel.Bord) {    
                Bord[i] = kleur.ToString();
                i++;
            }
            
            
            AandeBeurt = spel.AandeBeurt.ToString();
            Afgelopen = false;
            //Afgelopen = spel.Afgelopen();
            OverwegendeKleur = spel.OverwegendeKleur().ToString();
            
        }




        public int ID { get; set; }
        public string Omschrijving { get; set; }

        //het unieke token van het spel
        public string Token { get; set; }
        public string Speler1Token { get; set; }
        public string Speler2Token { get; set; }

        
        public string[] Bord { get; set; }
        public string AandeBeurt { get; set; }
        
        public bool Afgelopen;

        //welke kleur het meest voorkomend op het speelbord
        public string OverwegendeKleur;
    }
}
