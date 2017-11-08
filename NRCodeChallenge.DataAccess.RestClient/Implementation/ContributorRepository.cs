using NRCodeChallenge.DataAccess.RestClient.Client;
using NRCodeChallenge.Domain.Dtos;
using NRCodeChallenge.Domain.Entities;
using NRCodeChallenge.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NRCodeChallenge.DataAccess.RestClient.Implementation
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly IRestClient restClient;

        public ContributorRepository(IRestClient restClient)
        {
            this.restClient = restClient ?? throw new ArgumentNullException("restClient");
        }

        public async Task<IEnumerable<Contributor>> GetByCityAsync(string cityName, int page, int size)
        {
            var url = string.Format(ApiCalls.GetByCity, cityName, page, size);
            var result = await restClient.GetAsync<ContributorListDto>(url);

            return result != null ? result.Items : null;
        }
    }
}
