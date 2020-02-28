using System.Threading.Tasks;

namespace Lib
{
    public interface IAppInsightsProvider
    {
        Task<string> GetInsights(string query);
    }
}