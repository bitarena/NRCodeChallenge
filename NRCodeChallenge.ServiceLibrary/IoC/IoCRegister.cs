using LightInject;
using NRCodeChallenge.DataAccess.RestClient.Implementation;
using NRCodeChallenge.Domain.RepositoryContracts;
using NRCodeChallenge.ServiceLibrary.Contracts;
using NRCodeChallenge.ServiceLibrary.Implementation;

namespace NRCodeChallenge.ServiceLibrary.IoC
{
    public class IoCRegister
    {
        public static void Register(IServiceContainer container)
        {
            container.Register<IContributorFilterValidator, ContributorFilterValidator>();
            container.Register<IContributorRepository, ContributorRepository>();
            container.Register<INRCodeChallengeAppService, NRCodeChallengeAppService>();
        }
    }
}
