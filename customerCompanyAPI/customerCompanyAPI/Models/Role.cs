﻿using customerCompanyAPI.Data;
using customerCompanyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Models
{

    public class Role 
    {
        [Key]
        public string Id { set; get; }
        [Required]
        public string Name { set; get; }

    }
}
