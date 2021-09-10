using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Iaddress
    {
        List<Address> seeAddresses();
        Address seeAddress();
        bool addAddress();
        bool modifyAddress();
        bool activateAddress();
    }
}
