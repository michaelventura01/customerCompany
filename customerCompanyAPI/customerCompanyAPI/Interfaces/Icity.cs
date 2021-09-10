using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Icity
    {
        List<City> seeCities();
        City seeCity(string id, string countryId);
    }
}
