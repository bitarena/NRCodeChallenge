using LightInject;
using NRCodeChallenge.DataAccess.RestClient.Client;
using NRCodeChallenge.DataAccess.RestClient.Implementation;
using NRCodeChallenge.Domain.RepositoryContracts;

namespace NRCodeChallenge.DataAccess.RestClient.IoC
{
    public class IoCRegister
    {
        public static void Register(IServiceContainer container)
        {
            container.Register<IRestClientOptions, RestClientOptions>(new PerContainerLifetime());
            container.Register<IRestClient, Client.RestClient>(new PerContainerLifetime());
            container.Register<IContributorRepository, ContributorRepository>();
        }
    }
}
