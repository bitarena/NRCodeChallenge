using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NRCodeChallenge.DataAccess.RestClient.Client
{
    public class RestClient : IRestClient
    {
        private static HttpClient client = new HttpClient();

        public RestClient(IRestClientOptions restClientOptions)
        {
            Init(restClientOptions);
        }

        public async Task<T> GetAsync<T>(string requestUrl)
        {
            using (var response = await client.GetAsync(requestUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(content);
                    return result;
                }
                return default(T);
            }
        }

        private void Init(IRestClientOptions restClientOptions)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", GetType().ToString());

            if (!string.IsNullOrEmpty(restClientOptions.Username) && !string.IsNullOrEmpty(restClientOptions.Password))
            {
                var plainTextBytes = Encoding.UTF8.GetBytes($"{restClientOptions.Username}:{restClientOptions.Password}");
                var authentication = Convert.ToBase64String(plainTextBytes);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {authentication}");
            }
        }
    }
}
