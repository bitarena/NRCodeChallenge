using NRCodeChallenge.WebApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NRCodeChallenge.WebApi.Models
{
    public class ContributorRequest
    {
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only characters are allowed")]
        public string CityName { get; set; }

        [TakeValidate]
        public int Take { get; set; }
    }
}
