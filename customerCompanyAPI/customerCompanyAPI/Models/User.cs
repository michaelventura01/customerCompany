using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{
    public class User
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string UserName {set; get;}
        [Required]
        public string password { set; get; }
        public Role Role{set; get;}
        public Company Company { set; get; }
        public Status Status { set; get; }

    }
}
