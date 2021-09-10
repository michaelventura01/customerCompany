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
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime dateIn { get; set; }
        [Required]
        public string Email { get; set; }
        public Address Address { set; get; }
        [NotMapped]
        public List<Address> Addresses { set; get; }
        public Phone Phone { set; get; }
        [NotMapped]
        public List<Phone> Phones { set; get; }
        public Status Status { set; get; }
        public Company Company { set; get; }

        private readonly DataContext _data;
        public Customer(DataContext data)
        {
            _data = data;
        }



    }
}
