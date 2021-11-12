using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevChallenge.Models;

namespace AppDevChallenge.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> Get();
        Country Get(string id);
    }
}
