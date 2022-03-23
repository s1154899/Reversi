using ReversieISpelImplementatie.Model;

namespace ReversiRestApi.Model
{
    public interface ISpelRepository
    {
        void AddSpel(Spel spel);

        void RemoveSpel(string spelToken);
        void UpdateSpel(string spelToken, Spel spel);

        public List<Spel> GetSpellen();

        Spel GetSpel(string spelToken);



        // ...
    }
}
