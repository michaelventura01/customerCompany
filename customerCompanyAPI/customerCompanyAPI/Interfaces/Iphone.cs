using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Iphone
    {
        List<Phone> seePhones();
        Address seePhone();
        bool addPhone();
        bool modifyPhone();
        bool activatePhone();
    }
}
