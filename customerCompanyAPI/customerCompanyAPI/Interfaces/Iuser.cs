using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Iuser
    {
        List<User> seeUsers();
        User seeUser();
        bool addUser();
        bool modifyUser();
        bool activateUser();
    }
}
