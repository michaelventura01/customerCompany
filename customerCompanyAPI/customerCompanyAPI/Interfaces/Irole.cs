﻿using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Irole
    {
        Role seeRole();
        List<Role> seeRoles();
    }
}
