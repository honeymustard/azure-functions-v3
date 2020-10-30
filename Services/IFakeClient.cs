using System.Threading.Tasks;

namespace Honeymustard.Serivces
{
    public interface IFakeClient
    {
        Task<string> Get(string route);
    }
}