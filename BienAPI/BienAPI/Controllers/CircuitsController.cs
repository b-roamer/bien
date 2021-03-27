using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BienAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BienAPI.Controllers
{
    [Route("api/[controller]")]
    public class CircuitsController : Controller
    {
        private f1Context _db = new f1Context();
        // GET: api/values
        [HttpGet]
        public IQueryable<Circuit> Get(Pagination pagination)
        {
            return (from circuit in _db.Circuits
                    orderby circuit.Name
                    where circuit.Name.Contains(pagination.Search ?? "") && circuit.Country.Contains(pagination.Country ?? "")
                    select circuit)
                    .Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize);
        }

        [HttpGet("GetCountries")]
        public string[] GetCountries()
        {
            return (from circuit in _db.Circuits
                    orderby circuit.Country
                    select circuit.Country).Distinct().ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Circuit Get(int id)
        {
            return (from circuit in _db.Circuits
                    where circuit.CircuitId == id
                    select circuit).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Circuit newCircuit)
        {
            _db.Circuits.Add(newCircuit);
            _db.SaveChanges();
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Circuits.Remove(_db.Circuits.Where(c => c.CircuitId == id).FirstOrDefault());
            _db.SaveChanges();
        }
    }
}
