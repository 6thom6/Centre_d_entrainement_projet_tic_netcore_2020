using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IChevalRepository _cheval;

        public ChevalController(ChevalRepository cheval)
        {
            _cheval = cheval;
        }


        // GET: api/cheval
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cheval> chevals = _cheval.Get().Select(x => x);

            if (!(chevals is null))
                return Ok(chevals);
            else
                return NotFound();
        }

        // GET api/cheval/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cheval cheval = this._cheval.GetById(id);

            return Ok(cheval);
        }

        // POST api/<ChevalController>
        // Ajout = création
        [HttpPost]
        public IActionResult Post([FromBody] Cheval cheval)
        {
            try
            {
                this._cheval.Create(cheval);
                return Ok();
            }
            catch(Exception e)
            {
                return this.BadRequest();
            }
        }

        // PUT api/<ChevalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cheval value)
        {
            value.Id_Cheval = id;
            this._cheval.Update(value);
            return Ok();
        }

        // DELETE api/<ChevalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _cheval.Delete(id);

            return Ok(id);
        }
    }
}
