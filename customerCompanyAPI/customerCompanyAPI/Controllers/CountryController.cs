using customerCompanyAPI.Data;
using customerCompanyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly DataContext _data;
        public CountryController(DataContext data) {
            _data = data;
        }

        [HttpGet]
        public  async Task<ActionResult> Get()
        {
            var countries = await _data.Countries.ToListAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var country = await _data.Countries.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(country);
        }
    }
}

