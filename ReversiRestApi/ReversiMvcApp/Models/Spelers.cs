using System.ComponentModel.DataAnnotations;

namespace ReversiMvcApp.Models
{
    public class Spelers
    {
        [Key]
        public string Guid { get; set; }
        public string Name { get; set; }
        public int AantalGewonnen { get; set; }
        public int AantalVerloren { get; set; }
        public int AantalGelijk { get; set; }


    }
}
