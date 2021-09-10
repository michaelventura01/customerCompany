using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{
    public class City
    {
        [Key]
        public string Id { set; get; }
        [Required]
        public string Name { set; get; }

        public string countryId { set; get; }

        public Country country { set; get; }


        

        
    }
}
