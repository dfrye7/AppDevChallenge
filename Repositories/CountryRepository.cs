using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;

namespace AppDevChallenge.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private WorldContext context;
        public CountryRepository(WorldContext c)
        {
            context = c;
        }
        public IEnumerable<Country> Get()
        //gets all countries from db context
        {
            return context.Countries.ToList();
        }
        public Country Get(string id)
        //Gets a country from db context by Id
        {
            return context.Countries.Find(id);
        }
    }
}
