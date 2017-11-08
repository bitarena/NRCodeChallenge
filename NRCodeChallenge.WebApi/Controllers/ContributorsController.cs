using Microsoft.AspNetCore.Mvc;
using NRCodeChallenge.ServiceLibrary.Contracts;
using NRCodeChallenge.WebApi.Attributes;
using NRCodeChallenge.WebApi.Models;
using NRCodeChallenge.WebApi.Models.Mappers;
using System;
using System.Threading.Tasks;

namespace NRCodeChallenge.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ContributorsController : Controller
    {
        private readonly INRCodeChallengeAppService appService;

        public ContributorsController(INRCodeChallengeAppService appService)
        {
            this.appService = appService ?? throw new ArgumentNullException("appService");
        }

        // GET api/values
        [HttpGet]
        [Route("{cityname}/{take:int}", Name = "GetByCity")]
        public async Task<IActionResult> Get(ContributorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contributorsFilter = ContributorMapper.ToFilter(request);

            var contributors = await appService.GetContributorsByCityAsync(contributorsFilter);

            var response = ContributorMapper.ToResponse(contributors);

            return new ObjectResult(response);
        }
    }
}
