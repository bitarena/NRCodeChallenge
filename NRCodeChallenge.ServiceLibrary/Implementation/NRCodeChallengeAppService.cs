using NRCodeChallenge.Domain.Dtos;
using NRCodeChallenge.Domain.Entities;
using NRCodeChallenge.Domain.RepositoryContracts;
using NRCodeChallenge.ServiceLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRCodeChallenge.ServiceLibrary.Implementation
{
    public class NRCodeChallengeAppService : INRCodeChallengeAppService
    {
        private readonly IContributorRepository contributorRepository;
        private readonly IContributorFilterValidator contributorFilterValidator;
        // TODO: Remove the hardcoded
        private const int MaxPage = 100;

        public NRCodeChallengeAppService(IContributorRepository contributorRepository, 
                                         IContributorFilterValidator contributorFilterValidator)
        {
            this.contributorRepository = contributorRepository ?? throw new ArgumentNullException("contributorRepository");
            this.contributorFilterValidator = contributorFilterValidator ?? throw new ArgumentNullException("contributorFilterValidator");
        }

        public async Task<IEnumerable<Contributor>> GetContributorsByCityAsync(ContributorFilterDto filter)
        {
            Validate(filter);

            // I tried some values to check performance and I saw that no matter the size of the page I asked for
            // the response took the same time so I made the decission of keeping that simple and make a
            // generic approach that works the same for all the requests
            var tasks = new List<Task<IEnumerable<Contributor>>>();
            var page = 1;

            for (var count = 0; count < filter.Take; count += MaxPage)
            {
                tasks.Add(contributorRepository.GetByCityAsync(filter.CityName, page, MaxPage));
                page++;
            }

            var contributorPages = await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
            var result = contributorPages.SelectMany(x => x).ToList().Take(filter.Take);
            return result;
        }

        private void Validate(ContributorFilterDto filter)
        {
            if (!contributorFilterValidator.Validate(filter))
            {
                // TODO: Create a personalized exception to avoid hardcoded string here
                throw new ArgumentException("Check Take parameters, only 50, 100 or 150 are accepted");
            }
        }
    }
}
