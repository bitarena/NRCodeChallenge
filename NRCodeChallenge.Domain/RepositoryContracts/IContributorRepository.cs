using NRCodeChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NRCodeChallenge.Domain.RepositoryContracts
{
    public interface IContributorRepository
    {
        Task<IEnumerable<Contributor>> GetByCityAsync(string cityName, int page, int size);
    }
}
