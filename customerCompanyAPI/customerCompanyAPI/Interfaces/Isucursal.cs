using customerCompanyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Interfaces
{
    interface Isucursal
    {
        List<Sucursal> seeSucursal();
        Sucursal seeSucursals();
        bool addSucursal();
        bool modifySucursal();
        bool activateSucursal();
    }
}
