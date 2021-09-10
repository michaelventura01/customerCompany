using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AddressDirection { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime dateIn { get; set; }
        public City City { set; get; }
        
        public Country Country { set; get; }

        public Customer Customer { set; get; }

     }
}
