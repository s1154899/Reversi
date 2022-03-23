using Newtonsoft.Json;
using ReversiRestApi.Data;
using ReversiRestApi.Model;

namespace ReversiMvcApp.Models
{
    public static class APIReversi
    {
        public static string BaseUrl = "https://localhost:5001/";
        public static string GetSpellen = "/api/Spel";
        private static string _PostCreateSpel = "/api/Spel/Create";
        private static string _GetSpel = "/api/Spel/";
        public static string GetBeurt = "/api/Spel/Beurt/";
        public static string PostZet = "/api/Spel/Zet";
        private static string _GetWaitingSpellen = "api/Spel/waiting";

        private static HttpClient _client;

        static APIReversi() { 
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BaseUrl);
        }

        public static async Task<IEnumerable<SendableSpel>> GetWaitingSpel() {
            HttpResponseMessage response = await _client.GetAsync(_GetWaitingSpellen);

            response.EnsureSuccessStatusCode();
            var rawData = await response.Content.ReadAsStringAsync();
            var spel  = JsonConvert.DeserializeObject<IEnumerable<SendableSpel>>(rawData);

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


    }
}
