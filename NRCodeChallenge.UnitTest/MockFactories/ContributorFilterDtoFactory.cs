using NRCodeChallenge.Domain.Dtos;

namespace NRCodeChallenge.UnitTest.MockFactories
{
    public class ContributorFilterDtoFactory
    {
        private const string CityDefault = "london";
        private const int TakeDefault = 50;

        public static ContributorFilterDto CreateDefault()
        {
            var result = new ContributorFilterDto
            {
                CityName = CityDefault,
                Take = TakeDefault,
            };

            return result;
        }

        public static ContributorFilterDto CreateWithTake(int take)
        {
            var result = CreateDefault();
            result.Take = take;

            return result;
        }
    }
}
