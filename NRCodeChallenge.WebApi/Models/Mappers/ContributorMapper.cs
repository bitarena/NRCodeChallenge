using NRCodeChallenge.Domain.Dtos;
using NRCodeChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NRCodeChallenge.WebApi.Models.Mappers
{
    public static class ContributorMapper
    {
        public static ContributorFilterDto ToFilter(ContributorRequest request)
        {
            if (request == null)
            {
                return null;
            }

            var result = new ContributorFilterDto
            {
                CityName = request.CityName,
                Take = request.Take,
            };

            return result;
        }

        public static ContributorItem ToResponse(Contributor item)
        {
            if (item == null)
            {
                return null;
            }

            var result = new ContributorItem
            {
                Username = item.Username,
            };

            return result;
        }

        public static ContributorResponse ToResponse(IEnumerable<Contributor> items)
        {
            if (items == null)
            {
                return null;
            }

            var data = items.Select(x => ToResponse(x));

            var result = new ContributorResponse
            {
                Data = data,
            };

            return result;
        }
    }
}
