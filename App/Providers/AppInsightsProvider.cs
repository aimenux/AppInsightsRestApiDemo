using System.Net.Http;
using System.Threading.Tasks;
using App.Extractors;
using Microsoft.Extensions.Options;

namespace App.Providers
{
    public class AppInsightsProvider : IAppInsightsProvider
    {
        private readonly HttpClient _client;
        private readonly IOptions<Settings> _options;

        public AppInsightsProvider(HttpClient client, IOptions<Settings> options)
        {
            _client = client;
            _options = options;
        }

        public async Task<string> GetInsights(string query)
        {
            var requestUri = $"{_options.Value.ApiUrl}/{query}";
            var response = await _client.GetAsync(requestUri);
            return response.IsSuccessStatusCode 
                ? await response.Content.ReadAsStringAsync()
                : $"Failure cause is {response.ReasonPhrase}";
        }
    }
}
