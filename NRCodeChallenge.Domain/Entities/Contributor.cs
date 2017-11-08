using Newtonsoft.Json;

namespace NRCodeChallenge.Domain.Entities
{
    public class Contributor
    {
        [JsonProperty("login")]
        public string Username { get; set; }
    }
}
