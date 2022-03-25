using ReversiRestApi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReversiRestApi.Data
{
    public class SpelData : ISpelData
    {

        public int ID { get; set; }
        [Key]
        public string Token { get; set; }
        public string? Omschrijving { get; set; }
        [ForeignKey("Token")]
        public string Speler1Token { get; set; }

        public Speler NavigationProperty1 { get; set; }

        [ForeignKey("Token")]
        public string? Speler2Token { get; set; }

        public Speler NavigationProperty2 { get; set; }

        public string AandeBeurt { get; set; }
    }
}
