using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;

namespace AppDevChallenge.Classes
{
    public class CountryInfo
    {
        public string Name              { get; set; }
        public int Population           { get; set; }
        public decimal? LifeExpectancy  { get; set; }
        public CountryInfo() { }
        public CountryInfo(Country country)
        {
            Name = country.Name;
            Population = country.Population;
            LifeExpectancy = country.LifeExpectancy;
        }
    }
}
