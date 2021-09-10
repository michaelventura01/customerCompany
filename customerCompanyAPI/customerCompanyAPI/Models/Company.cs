using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Status Status { get; set; }

        public Sucursal Sucursal { set; get; }
        [NotMapped]
        public List<Sucursal> Sucursals { set; get; }
        [NotMapped]
        public List<Customer> Customers { set; get; }
        public Customer Customer { set; get; }

        [NotMapped]
        public List<User> Users { set; get; }
        [NotMapped]
        public User User { set; get; }

   
    }
}
