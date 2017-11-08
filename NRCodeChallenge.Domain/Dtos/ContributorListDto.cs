using NRCodeChallenge.Domain.Entities;
using System.Collections.Generic;

namespace NRCodeChallenge.Domain.Dtos
{
    public class ContributorListDto
    {
        public IEnumerable<Contributor> Items { get; set; }
    }
}
