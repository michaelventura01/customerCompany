using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{
    public class Sucursal
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public Address Address { set; get; }
        public List<Address> Addresses { set; get; }
        [Required]
        public Phone Phone { set; get; }
        public List<Phone> Phones { set; get; }

    }
}
