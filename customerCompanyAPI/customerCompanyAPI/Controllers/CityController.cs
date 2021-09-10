using customerCompanyAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customerCompanyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly DataContext _data;
        public CityController(DataContext data)
        {
            _data = data;
        }
        [HttpGet("{countryId}")]
        public async Task<ActionResult> Get(string countryId)
        {
            var cities = await _data.Cities.Where(c => c.country.Id == countryId).ToListAsync();
            return Ok(cities);
        }

        [HttpGet("{id}/{countryId}")]
        public async Task<ActionResult> Get(string id, string countryId)
        {
            var city = await _data.Cities.FirstOrDefaultAsync(c => c.Id == id && c.country.Id == countryId);
            if (city == null) {
                return NotFound();
            }
            return Ok(city);
        }
    }
}
