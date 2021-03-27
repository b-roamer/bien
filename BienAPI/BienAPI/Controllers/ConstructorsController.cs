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
    public class ConstructorsController : Controller
    {
        private f1Context _db = new f1Context();
        // GET: api/values
        [HttpGet]
        public IQueryable<Constructor> Get(Pagination pagination)
        {
            return (from con in _db.Constructors
                    orderby con.Name
                    where con.Name.Contains(pagination.Search ?? "") && con.Nationality.Contains(pagination.Nationality ?? "")
                    select con)
                    .Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize);
        }
        [HttpGet("GetCountries")]
        public string[] GetCountries()
        {
            return (from con in _db.Constructors
                    orderby con.Nationality
                    select con.Nationality).Distinct().ToArray();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public Constructor Get(int id)
        {
            return (from con in _db.Constructors
                    where con.ConstructorId == id
                    select con).FirstOrDefault(); ;
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
