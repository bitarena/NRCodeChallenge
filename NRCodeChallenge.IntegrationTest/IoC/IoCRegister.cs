using LightInject;

namespace NRCodeChallenge.IntegrationTest.IoC
{
    public class IoCRegister
    {
        public static IServiceContainer Register()
        {
            var container = new ServiceContainer();
            DataAccess.RestClient.IoC.IoCRegister.Register(container);
           
            return container;
        }
    }
}
