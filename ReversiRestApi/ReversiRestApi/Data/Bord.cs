using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReversiRestApi.Data
{
    public class Bord
    {
        [Key]
        [ForeignKey("Token")]
        public string Token { get; set; }
        
        public Spel Spel { get; set; }
        
        public string BespeeldBord  { get; set; }
    }
}
