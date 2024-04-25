//using Newtonsoft.Json;

//namespace BusinessEvents.Client.Services
//{
//    public class ApiService
//    {
//        private readonly HttpClient _httpClient;

//        public ApiService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<IEnumerable<T>> Get<T>(string endpoint)
//        {
//            var response = await _httpClient.GetAsync(endpoint);

//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
//            }

//            return null;
//        }
//    }
//}
