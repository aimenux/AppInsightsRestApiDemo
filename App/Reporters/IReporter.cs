using System.Threading.Tasks;

namespace App.Reporters
{
    public interface IReporter
    {
        Task PrintAsync();
    }
}
