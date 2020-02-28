using System.Threading.Tasks;

namespace App.Providers
{
    public interface IAppInsightsProvider
    {
        Task<string> GetInsights(string query);
    }
}