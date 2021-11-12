using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;

namespace AppDevChallenge.Classes
{
    public class PopulationInfo
    {
        public int TotalPopulation { get; set; }
        public string CountryName { get; set; }

        public PopulationInfo() { }

        public PopulationInfo(Country country)
        {
            CountryName = country.Name;
            TotalPopulation = country.Population;

        }
    }
}
