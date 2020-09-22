using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepository;
using DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoinsController : ControllerBase
    {
        private ISoinsRepository _soinsRepository;

        public SoinsController (SoinsRepository soins)
        {
            _soinsRepository = soins;
        }

        // GET: api/<SoinsController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Soins> soins = _soinsRepository.GetallSoins().Select(x => x);
            if (!(soins is null))
                return Ok(soins);
            else
                return NotFound();
        }

        // GET api/<SoinsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Soins soins = this._soinsRepository.GetById(id);
            if (!(soins is null))
                return Ok(soins);
            else
                return NotFound();
        }

        // POST api/<SoinsController>
        [HttpPost]
        public IActionResult Post([FromBody] Soins soins)
        {
            int Success = _soinsRepository.Create(soins);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<SoinsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Soins soins)
        {
            this._soinsRepository.Update(id, soins);
            return Ok();
        }

        // DELETE api/<SoinsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new Exception();
        }
    }
}
