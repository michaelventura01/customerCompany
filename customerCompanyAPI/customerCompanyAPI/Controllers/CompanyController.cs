using customerCompanyAPI.Data;
using Microsoft.AspNetCore.Http;
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
    public class CompanyController : Controller
    {
        // GET: CompanyController
        private readonly DataContext _data;
        public CompanyController(DataContext data)
        {
            _data = data;
        }
        
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var companies = await _data.VW_companies_branches.ToListAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var company = await _data.VW_companies_branches.FirstOrDefaultAsync(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC createCompany {0}, {1}, {2}, {3}, {4}, {5}", collection["Name"], collection["Phone"], collection["Address"], collection["City"], collection["Zip"], collection["BranchName"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC modifyCompany {0}, {1}, {2}, {3}, {4}, {5}, {6}", id, collection["Name"], collection["Phone"], collection["Address"], collection["City"], collection["Zip"], collection["BranchName"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC activateCompany {0}, {1}", id, collection["Status"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
