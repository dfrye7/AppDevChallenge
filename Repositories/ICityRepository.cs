using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;


namespace AppDevChallenge.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> Get();
        City Get(string id);
    }
}
