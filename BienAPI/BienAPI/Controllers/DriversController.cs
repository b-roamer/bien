using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BienAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Authentication;

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
        public object Get(int id, [FromQuery] Pagination pagination)
        {
            var driver = _db.Drivers.Find(id);
            var results = (from r in _db.Results
                           join race in _db.Races
                           on r.RaceId equals race.RaceId
                           join c in _db.Constructors
                           on r.ConstructorId equals c.ConstructorId
                           join s in _db.Statuses
                           on r.StatusId equals s.StatusId
                           join circuit in _db.Circuits
                           on race.CircuitId equals circuit.CircuitId
                           where r.DriverId == id
                           select new
                           {
                               r.RaceId,
                               Constructor = c.Name,
                               race.Name,
                               Circuit = circuit.Name,
                               r.Number,
                               r.Grid,
                               r.Position,
                               r.Points,
                               r.Laps,
                               r.Time,
                               r.Ranks,
                               Status = s.Status1,
                               race.Date
                           }).ToList().Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize);

            var totalRaces = (from r in _db.Results
                              where r.DriverId == id
                              select r.RaceId).Count();

            var totalPoints = (from r in _db.Results
                               where r.DriverId == id
                               select r.Points).Sum();

            return new { driver, results, totalRaces, totalPoints };
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
