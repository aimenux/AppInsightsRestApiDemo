using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lib
{
    public class AppInsightsProvider : IAppInsightsProvider
    {
        private readonly HttpClient _client;

        public AppInsightsProvider(HttpClient client)
        {
            _client = client;
        }

        public Task<string> GetInsights(string query)
        {
            throw new NotImplementedException();
        }
    }
}
