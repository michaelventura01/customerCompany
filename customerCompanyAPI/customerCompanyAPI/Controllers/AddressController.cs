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
    public class AddressController : Controller
    {
        private readonly DataContext _data;
        public AddressController(DataContext data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult> Get(int customerID)
        {
            var addresses = await _data.VW_customer_addresses.Where(p => p.Customer.Id == customerID).ToListAsync();
            return Ok(addresses);
        }
        [HttpGet("{id}/{customerID}")]
        public async Task<ActionResult> Get(int id, int customerID)
        {
            var address = await _data.VW_customer_addresses.FirstOrDefaultAsync(c => c.Id == id && c.Customer.Id == customerID);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //@company int, @address text, @city varchar(4), @zip varchar(6), @customer int
                this._data.Database.ExecuteSqlRaw("EXEC AddCustomerAddress {0}, {1}, {2}, {3}, {4}", collection["Company"], collection["Address"], collection["City"], collection["Zip"], collection["Customer"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC ModifyCustomerAddress {0}, {1}, {2}, {3}", id, collection["Address"], collection["Zip"], collection["City"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC activateCustomerAddress {0}, {1}", id, collection["Status"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
