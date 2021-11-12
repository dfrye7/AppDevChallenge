using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;
using AppDevChallenge.Repositories;
using AppDevChallenge.Classes;

namespace AppDevChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationByCountryController : ControllerBase
    {
        private ICountryRepository countryRepository;
        public PopulationByCountryController(ICountryRepository c)
        {
            countryRepository = c;
        }

        [HttpGet("{country}")]
        public PopulationInfo GetCountryByRegion(string country)
        /*Return country name, total population by Country Code*/
        {
            Country c = countryRepository.Get(country);
            PopulationInfo population = new PopulationInfo(c);

            return population;
        }
    }
}
