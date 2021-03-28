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
    public class ResultsController : Controller
    {
        private static f1Context _db = new f1Context();
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{raceId}")]
        public static IQueryable<Object> Get(int raceId)
        {
            return from res in _db.Results
                   join race in _db.Races on res.RaceId equals race.RaceId
                   join driver in _db.Drivers on res.DriverId equals driver.DriverId
                   join ctor in _db.Constructors on res.ConstructorId equals ctor.ConstructorId
                   join status in _db.Statuses on res.StatusId equals status.StatusId
                   where race.RaceId == raceId
                   orderby res.Position.HasValue descending, res.Position
                   select new
                   {
                       Position = res.Position,
                       Driver = $"{driver.Forename} {driver.Surname}",
                       Constructor = ctor.Name,
                       Time = res.Time,
                       Status = status.Status1,
                       DriverId = driver.DriverId,
                       Url = driver.Url
                   };
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
