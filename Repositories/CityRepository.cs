using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;

namespace AppDevChallenge.Repositories
{
    public class CityRepository : ICityRepository
    {
        private WorldContext context;
        public CityRepository(WorldContext c)
        {
            context = c;
        }
        public IEnumerable<City> Get()
        //gets all cities from db context
        {
            return context.Cities.ToList();
        }
        public City Get(string id)
        //Gets a city from db context by Id
        {
            return context.Cities.Find(id);
        }
    }
}
