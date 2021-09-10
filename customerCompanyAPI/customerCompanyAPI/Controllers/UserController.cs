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
    public class UserController : Controller
    {
        private readonly DataContext _data;
        public UserController(DataContext data)
        {
            _data = data;
        }
        // GET: UserController
        
        [HttpGet("{companyId}")]
        public async Task<ActionResult> Get(int companyID)
        {
            var user = await _data.VW_User_Company.Where(p => p.Company.Id == companyID).ToListAsync();
            return Ok(user);
        }
        [HttpGet("{id}/{companyId}")]
        public async Task<ActionResult> Get(int id, int companyId)
        {
            var user = await _data.VW_User_Company.FirstOrDefaultAsync(c => c.Id == id && c.Company.Id == companyId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(IFormCollection collection)
        {
            var user = await _data.VW_User_Company.FirstOrDefaultAsync(
                c => c.UserName == collection["User"] && 
                c.Company.Id == collection["CompanyID"] && 
                c.password == collection["Password"]);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                this._data.Database.ExecuteSqlRaw("EXEC createUserCompany {0}, {1}, {2}, {3}, {4}", collection["Company"], collection["User"], collection["Password"], collection["Status"], collection["Rol"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC modifyUserCompany {0}, {1}, {2}, {3}, {4}, {5}", id, collection["Company"], collection["User"], collection["Password"], collection["Status"], collection["Rol"]);
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
                this._data.Database.ExecuteSqlRaw("EXEC activateUserCompany {0}, {1}", id, collection["Status"]);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
