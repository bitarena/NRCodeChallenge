using System.Collections.Generic;

namespace NRCodeChallenge.WebApi.Models
{
    public class ContributorResponse
    {
        public IEnumerable<ContributorItem> Data { get; set; }
    }
}
