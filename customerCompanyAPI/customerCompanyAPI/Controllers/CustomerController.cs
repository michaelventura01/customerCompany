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
    public class CustomerController : Controller
    {
        private readonly DataContext _data;
        public CustomerController(DataContext data)
        {
            _data = data;
        }

        public async Task<ActionResult> Get(int companyId)
        {
            var customers = await _data.VW_Customer_Companies.Where(c => c.Company.Id == companyId).ToListAsync();
            return Ok(customers);
        }

        
        [HttpGet("{id}/{companyId}")]
        public async Task<ActionResult> Get(int id, int companyId)
        {

            var customer = await _data.VW_Customer_Companies.FirstOrDefaultAsync(c => c.Company.Id == companyId && c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC createCustomer {0}, {1}, {2}, {3}, {4}, {5}, {6}", collection["Name"], collection["Email"], collection["Address"], collection["City"], collection["Zip"], collection["Phone"], collection["Company"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC modifyCustomer {0}, {1}, {2}", id, collection["Name"], collection["Email"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // POST: UserController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC deleteCustomer {0}", id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activate(int id, IFormCollection collection)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC activateCustomer {0}, {1}", id, collection["Status"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
