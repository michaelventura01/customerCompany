using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Icompany
    {
        List<Company> seeCompanies();
        Company seeCompany();
        bool addCompany();
        bool modifyCompany();
        bool activateCompany();
    }
}
