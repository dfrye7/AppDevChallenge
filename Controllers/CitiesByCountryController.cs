using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;
using AppDevChallenge.Repositories;

namespace AppDevChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesByCountryController : ControllerBase
    {
        private ICityRepository cityRepository;
        public CitiesByCountryController(ICityRepository c)
        {
            cityRepository = c;
        }

        [HttpGet("{country}")]
        public IEnumerable<string> GetCitiesByCountry(string country)
        /*Return list of city names by Country Code*/
        {
            return cityRepository.Get()?.ToList()?.Where(i => i.CountryCode == country)?.Select(o => o.Name)?.ToList(); ;
        }
    }
}
