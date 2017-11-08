using NRCodeChallenge.Domain.Dtos;
using NRCodeChallenge.ServiceLibrary.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NRCodeChallenge.ServiceLibrary.Implementation
{
    public class ContributorFilterValidator : IContributorFilterValidator
    {
        IEnumerable<int> takes = new List<int> { 50, 100, 150 };

        public bool Validate(ContributorFilterDto filter)
        {
            if (filter == null)
            {
                return false;
            }
            else if (!takes.Contains(filter.Take))
            {
                return false;
            }
            return true;
        }
    }
}
