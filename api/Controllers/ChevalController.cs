using System;
using System.Collections.Generic;
using System.Linq;
using DAL.IRepository;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChevalController : ControllerBase
    {
        private IChevalRepository _chevalRepository;

        public ChevalController(ChevalRepository cheval)
        {
            _chevalRepository = cheval;
        }

        // GET: api/cheval
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cheval> chevals = _chevalRepository.Get().Select(x => x);

            if (!(chevals is null))
                return Ok(chevals);
            else
                return NotFound();
        }

        // GET api/cheval/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cheval cheval = this._chevalRepository.GetById(id);

            if (!(cheval is null))
                return Ok(cheval);
            else 
                return NotFound();
        }

        // POST api/<ChevalController>
        // Ajout = création
        [HttpPost]
        public IActionResult Post([FromBody] Cheval cheval)
        {
            int Success = _chevalRepository.Create(cheval);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<ChevalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cheval cheval)
        {
            this._chevalRepository.Update(id, cheval);
            return Ok();
        }

        // DELETE api/<ChevalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _chevalRepository.Delete(id);

            return Ok(id);
        }
    }
}
