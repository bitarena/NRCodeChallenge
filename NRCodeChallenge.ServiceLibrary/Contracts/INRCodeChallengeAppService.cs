using NRCodeChallenge.Domain.Dtos;
using NRCodeChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NRCodeChallenge.ServiceLibrary.Contracts
{
    public interface INRCodeChallengeAppService
    {
        Task<IEnumerable<Contributor>> GetContributorsByCityAsync(ContributorFilterDto filter);
    }
}
