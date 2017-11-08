using System.Threading.Tasks;

namespace NRCodeChallenge.DataAccess.RestClient.Client
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string requestUrl);
    }
}
