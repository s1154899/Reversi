﻿using ReversiRestApi.Model;

namespace ReversiRestApi.Model
{
    public class SpelRepositoryList : ISpelRepository
    {
        // Lijst met tijdelijke spellen
        public List<Spel> Spellen { get; set; }

        public SpelRepositoryList()
        {
            Spel spel1 = new Spel();
            Spel spel2 = new Spel();
            Spel spel3 = new Spel();
            Spel spel4 = new Spel();

            spel1.Speler1Token = "abcdef";
            spel1.Omschrijving = "Potje snel reveri, dus niet lang nadenken";
            spel2.Speler1Token = "ghijkl";
            spel2.Speler2Token = "mnopqr";
            spel2.Omschrijving = "Ik zoek een gevorderde tegenspeler!";
            spel3.Speler1Token = "stuvwx";
            spel3.Omschrijving = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";
            spel4.Speler1Token = "stuvwx";
            spel4.Omschrijving = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";


            Spellen = new List<Spel> { spel1, spel2, spel3,spel4 };
        }

        public void AddSpel(Spel spel)
        {
            Spellen.Add(spel);
        }

        //gets all spellen
        public List<Spel> GetSpellen()
        {
           return Spellen;
        }

        //Creates a new empty spel if spel is not found
        public Spel GetSpel(string spelToken)
        {
            Spel spel = Spellen.Find(F => F.Token == spelToken);
            return spel == null ? new Spel() : spel;
        }

        public void RemoveSpel(string spelToken)
        {
            Spellen.Remove(Spellen.FirstOrDefault(spel => spel.Token == spelToken));
        }

        public void UpdateSpel(string spelToken, Spel spel)
        {
            try
            {
                int index = Spellen.FindIndex(spel => spel.Token == spelToken);
                Spellen[index] = spel;
            }
            catch (Exception e) { }
        }

        // ...

    }

}
