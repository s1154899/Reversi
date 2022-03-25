using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReversiRestApi.Data
{
    public class Bord
    {
        public Bord() { }
        public Bord(string token, string bespeeldbord) { 
            Token = token;
            BespeeldBord = bespeeldbord;

        }

        [Key]
        [ForeignKey("Token")]
        public string Token { get; set; }
        
        public SpelData Spel { get; set; }
        
        public string BespeeldBord  { get; set; }
    }
}
