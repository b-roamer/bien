using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BienAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BienAPI.Controllers
{
    [Route("api/[controller]")]
    public class DriversController : Controller
    {
        private f1Context _db = new f1Context();
        // GET: api/values
        [HttpGet]
        public IQueryable<Driver> Get(Pagination pagination)
        {
            return (from driver in _db.Drivers
                    orderby driver.Forename, driver.Surname
                    where (driver.Forename.Contains(pagination.Search ?? "")
                        || driver.Surname.Contains(pagination.Search ?? ""))
                        && driver.Nationality.Contains(pagination.Nationality ?? "")
                    select driver).Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize); ;
        }

        [HttpGet("GetCountries")]
        public string[] GetCountries()
        {
            return (from driver in _db.Drivers
                    orderby driver.Nationality
                    select driver.Nationality).Distinct().ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
