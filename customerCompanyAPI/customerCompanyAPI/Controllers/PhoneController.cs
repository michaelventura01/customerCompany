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
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly DataContext _data;
        public PhoneController(DataContext data)
        {
            _data = data;
        }
        
       [HttpGet("{customerId}")]
        public async Task<ActionResult> Get(int customerID)
        {
            var phones = await _data.VW_customers_phones.Where(p => p.Customer.Id == customerID).ToListAsync();
            return Ok(phones);
        }
       [HttpGet("{id}/{customerID}")]
        public async Task<ActionResult> Get(int id, int customerID)
        {
            var phone = await _data.VW_customers_phones.FirstOrDefaultAsync(c => c.Id == id && c.Customer.Id == customerID);
            if (phone == null)
            {
                return NotFound();
            }
            return Ok(phone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //@company int, @address text, @city varchar(4), @zip varchar(6), @customer int
                this._data.Database.ExecuteSqlRaw("EXEC AddCustomerPhone {0}, {1}, {2}", collection["Company"], collection["Customer"], collection["Phone"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC ModifyCustomerPhone {0}, {1}", id, collection["Phone"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC activateCustomerPhone {0}, {1}", id, collection["Status"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
