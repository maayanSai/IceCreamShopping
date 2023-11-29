namespace IceCreamsShopping.ApiService
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ApiServices(string apiKey)
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(300)
            };
            _apiKey = apiKey;

        }

        public async Task<T> CallServiceApi<T>(string apiUrl)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read and deserialize the response content
                    string responseContent = await response.Content.ReadAsStringAsync();
                    T responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
                    return responseData;
                }
                else
                    throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception($"API request failed: {ex.Message}");
            }
        }
    }
}
