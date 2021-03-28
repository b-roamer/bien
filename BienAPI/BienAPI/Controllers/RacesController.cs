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
    public class RacesController : Controller
    {
        private f1Context _db = new f1Context();
        // GET: api/values
        [HttpGet]
        public IQueryable<Object> Get(Pagination pagination)
        {
            return (from race in _db.Races
                    orderby race.Date descending, race.Name
                    where race.Name.Contains(pagination.Search ?? "")
                    && race.Year.ToString().Contains(pagination.Year ?? "")
                    && _db.Circuits.Where(c => c.CircuitId == race.CircuitId).FirstOrDefault().Name.Contains(pagination.Circuit ?? "")
                    select new
                    {
                        RaceId = race.RaceId,
                        Circuit = _db.Circuits.Where(c => c.CircuitId == race.CircuitId).FirstOrDefault().Name,
                        Name = race.Name,
                        Date = race.Date,
                        Url = race.Url,
                        Results = ResultsController.Get(race.RaceId).ToList(),
                    }).Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize);
        }
        [HttpGet("GetYears")]
        public int[] GetYears()
        {
            return (from race in _db.Races
                    orderby race.Year descending
                    select race.Year).Distinct().ToArray();
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
