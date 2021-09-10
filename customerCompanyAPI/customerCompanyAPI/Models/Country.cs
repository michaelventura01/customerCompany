using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{
    public class Country
    {
        [Key]
        [Display(Name = "CountryId")]
        public string Id { set; get; }
        [Required]
        public String Name { set; get; }

        public List<Country> countries { set; get; }

    }
}
