using System.ComponentModel.DataAnnotations;

namespace ReversiRestApi.Data
{
    public class Speler
    {
        [Key]
        public string Token { get; set; }
        public string Name { get; set; }



    }
}
