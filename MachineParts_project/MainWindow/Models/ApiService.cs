using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;


namespace Examen.Models
{
    internal class ApiService
    {
        // Variables ----------------------------------------------------------------------------------------------------------------------------
        private readonly HttpClient _httpClient;

        // Constructor ----------------------------------------------------------------------------------------------------------------------------
        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);
        }

        // Methodes ---------------------------------------------------------------------------------------------------------------------------
        public async Task<bool> PostDataAsync<T>(string url, T data)
        {
            try
            {
                // Serialize the data to JSON and post it
                var jsonData = JsonSerializer.Serialize(data);
                var response = await _httpClient.PostAsJsonAsync(url, data);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                // Handle non-success status codes here
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, {responseBody}");

                return false;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network errors)
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }
}
