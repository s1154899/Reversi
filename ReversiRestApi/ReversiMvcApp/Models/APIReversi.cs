using Newtonsoft.Json;
using ReversieISpelImplementatie.Model;
using ReversiRestApi.Data;
using ReversiRestApi.Model;

namespace ReversiMvcApp.Models
{
    public static class APIReversi
    {
        public static string BaseUrl = "https://localhost:5001/";
        public static string GetSpellen = "/api/Spel";
        private static string _PostCreateSpel = "/api/Spel/Create";
        private static string _PostJoinSpel = "/api/Spel/Join/";
        private static string _getSpellenSpeler = "api/Spel/Playing";
        private static string _GetSpel = "/api/Spel/";
        public static string GetBeurt = "/api/Spel/Beurt/";
        public static string PostZet = "/api/Spel/Zet";
        private static string _GetWaitingSpellen = "api/Spel/waiting";

        private static HttpClient _client;

        static APIReversi() { 
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BaseUrl);
        }

        public static async Task<IEnumerable<Spel>> GetWaitingSpel() {
            HttpResponseMessage response = await _client.GetAsync(_GetWaitingSpellen);

            response.EnsureSuccessStatusCode();
            var rawData = await response.Content.ReadAsStringAsync();
            var spel  = JsonConvert.DeserializeObject<IEnumerable<Spel>>(rawData);

            return spel;

        }
        public static async Task<IEnumerable<Spel>> GetSpellenSpeler(string spelerToken)
        {
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("spelerToken", spelerToken);
            HttpResponseMessage response = await _client.GetAsync(_getSpellenSpeler);

            response.EnsureSuccessStatusCode();
            var rawData = await response.Content.ReadAsStringAsync();
            var spel = JsonConvert.DeserializeObject<IEnumerable<Spel>>(rawData);
            _client.DefaultRequestHeaders.Clear();
            return spel;

        }

        public static async Task<string> PostCreateSpel(string spelerToken, string omschrijving) {

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("speler1Token", spelerToken);
            _client.DefaultRequestHeaders.Add("omschrijving", omschrijving);

            HttpResponseMessage response = await _client.GetAsync(_PostCreateSpel);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostJoin(string Token, string spelerToken) {
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("speler2Token", spelerToken);

            HttpResponseMessage response = await _client.GetAsync(_PostJoinSpel+Token);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();

        }


    }
}
