using Newtonsoft.Json;
using ReversiRestApi.Data;
using ReversiRestApi.Model;

namespace ReversiMvcApp.Models
{
    public static class APIReversi
    {
        public static string BaseUrl = "https://localhost:5001/";
        //public static string BaseUrl = "https://localhost:7059/";
        private static string _GetSpel = "/api/Spel/";
        private static string _PostCreateSpel = "/api/Spel/Create";
        private static string _PostJoinSpel = "/api/Spel/Join/";
        private static string _getSpellenSpeler = "api/Spel/Playing";
        public static string GetBeurt = "/api/Spel/Beurt/";
        private static string _PostZet = "/api/Spel/Zet";
        private static string _GetWaitingSpellen = "api/Spel/waiting";
        private static string _PostRemoveSPel = "api/Spel/Remove";
        private static string _PostDoPas = "api/Spel/Pas";
        private static string _GetIsAfgelopen = "api/Spel/afgelopen";

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

        public static async Task<Spel> GetSpel(string token)
        {
            HttpResponseMessage response = await _client.GetAsync(_GetSpel+token);

            response.EnsureSuccessStatusCode();
            var rawData = await response.Content.ReadAsStringAsync();
            var spel = JsonConvert.DeserializeObject<Spel>(rawData);

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


            var data = new StringContent("");

            HttpContent content = data;

            HttpResponseMessage response = await _client.PostAsync(_PostCreateSpel,content);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostJoin(string Token, string spelerToken) {
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("speler2Token", spelerToken);

            var data = new StringContent("");

            HttpContent content = data;

            HttpResponseMessage response = await _client.PostAsync(_PostJoinSpel+Token, content);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();

        }

        public static async Task<string> PostRemoveSPel(string Token)
        {
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("spelToken", Token);

            var data = new StringContent("");

            HttpContent content = data;

            HttpResponseMessage response = await _client.PostAsync(_PostRemoveSPel , content);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();

        }


        public static async Task<string> PostDoZet(string spelToken, string rijZet,string kolomZet,string speler)
        {

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("spelToken", spelToken);
            _client.DefaultRequestHeaders.Add("rijZet", rijZet);
            _client.DefaultRequestHeaders.Add("kolomZet", kolomZet);
            _client.DefaultRequestHeaders.Add("speler", speler);


            var data = new StringContent("");

            HttpContent content = data;

            HttpResponseMessage response = await _client.PostAsync(_PostZet, content);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostDoPas(string spelToken, string speler)
        {

            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("spelToken", spelToken);
            _client.DefaultRequestHeaders.Add("speler", speler);


            var data = new StringContent("");

            HttpContent content = data;

            HttpResponseMessage response = await _client.PostAsync(_PostDoPas, content);
            _client.DefaultRequestHeaders.Clear();
            return await response.Content.ReadAsStringAsync();
        }



        public static async Task<String> IsAfgelopen(string spelToken)
        {
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Add("spelToken", spelToken);
            HttpResponseMessage response = await _client.GetAsync(_GetIsAfgelopen);

            response.EnsureSuccessStatusCode();
            var rawData = await response.Content.ReadAsStringAsync();
            _client.DefaultRequestHeaders.Clear();
            return rawData;

        }

    }
}
