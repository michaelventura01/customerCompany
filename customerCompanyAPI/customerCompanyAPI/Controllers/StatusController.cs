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
    public class StatusController : Controller
    {
        private readonly DataContext _data;
        public StatusController(DataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var status = await _data.Status.ToListAsync();
            return Ok(status);
        }
    }
}
