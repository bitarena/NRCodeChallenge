using NRCodeChallenge.Domain.Dtos;

namespace NRCodeChallenge.ServiceLibrary.Contracts
{
    public interface IContributorFilterValidator
    {
        bool Validate(ContributorFilterDto filter);
    }
}
