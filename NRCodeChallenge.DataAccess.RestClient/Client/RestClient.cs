using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NRCodeChallenge.DataAccess.RestClient.Client
{
    public class RestClient : HttpClient, IRestClient
    {
        public RestClient(IRestClientOptions restClientOptions)
        {
            Init(restClientOptions);
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
            return default(T);
        }

        private void Init(IRestClientOptions restClientOptions)
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent", GetType().ToString());

            if (!string.IsNullOrEmpty(restClientOptions.Username) && !string.IsNullOrEmpty(restClientOptions.Password))
            {
                var plainTextBytes = Encoding.UTF8.GetBytes($"{restClientOptions.Username}:{restClientOptions.Password}");
                var authentication = Convert.ToBase64String(plainTextBytes);
                DefaultRequestHeaders.Add("Authorization", $"Basic {authentication}");
            }
        }
    }
}
