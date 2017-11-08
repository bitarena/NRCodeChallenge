namespace NRCodeChallenge.DataAccess.RestClient.Implementation
{
    public class ApiCalls
    {
        public const string GetByCity = "https://api.github.com/search/users?q=type:user+location:{0}&sort=repositories&order=desc&page={1}&per_page={2}";
    }
}
