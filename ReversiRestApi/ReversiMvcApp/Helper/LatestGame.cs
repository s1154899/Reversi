using ReversiMvcApp.Models;
using ReversiRestApi.Model;

namespace ReversiMvcApp.Helper
{
    public static class LatestGame
    {
        public static Spel GetLatestSpel() {

            Spel spel = APIReversi.GetWaitingSpel().Result.ElementAtOrDefault(0);
            if (spel == null) {
                spel = new Spel();            
            }
            return spel;
            
        }
    }
}
