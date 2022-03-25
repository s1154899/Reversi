namespace ReversiRestApi.Model
{
    public interface ISpelData
    {
        int ID { get; set; }
        string Omschrijving { get; set; }

        //het unieke token van het spel
        string Token { get; set; }
        string Speler1Token { get; set; }
        string Speler2Token { get; set; }


        string AandeBeurt { get; set; }
    }
}
