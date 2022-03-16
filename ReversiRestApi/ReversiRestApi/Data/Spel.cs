using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReversiRestApi.Data
{
    public class Spel
    {
        [Key]
        public string Token { get; set; }
        public string? Omschrijving { get; set; }
        [ForeignKey("Token")]
        public string? Speler1 { get; set; }

        public Speler NavigationProperty1 { get; set; }

        [ForeignKey("Token")]
        public string? Speler2 { get; set; }

        public Speler NavigationProperty2 { get; set; }
        
        public string Aandebeurd { get; set; }

    }
}
