﻿using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Icustomer
    {
        List<Customer> seeCustomers();
        Customer seeCustomer();
        bool addCustomer();
        bool modifyCustomer();
        bool activateCustomer();
    }
}
