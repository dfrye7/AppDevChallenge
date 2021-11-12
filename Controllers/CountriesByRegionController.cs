using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Repositories;
using AppDevChallenge.Models;
using AppDevChallenge.Classes;

namespace AppDevChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesByRegionController : ControllerBase
    {
        private ICountryRepository countryRepository;
        public CountriesByRegionController(ICountryRepository c)
        {
            countryRepository = c;
        }

        [HttpGet("{region}")]
        public IEnumerable<CountryInfo> GetCountryByRegion(string region)
        /*Return list of country name, population, LifeExpentancy by Region*/
        {
            List<Country> countries = countryRepository.Get()?.ToList()?.Where(i => i.Region == region)?.ToList();
            List<CountryInfo> countryInfo = new List<CountryInfo>();
            foreach (Country c in countries)
            {
                //we only want certain columns of Country info. CountryInfo constructor stores the appropriate attributes.
                countryInfo.Add(new CountryInfo(c));
            }
            return countryInfo;
        }
    }
}
