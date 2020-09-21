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
    public class HistoriqueController : ControllerBase
    {
        private IHistoRipository _histoRipository;

        public HistoriqueController(HistoRipository historique)
        {
            _histoRipository = historique;
        }
        // GET: api/<HistoriqueController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Historique> historique = _histoRipository.GetallHistorique().Select(x => x);
            if (!(historique is null))
                return Ok(historique);
            else
                return NotFound();
        }

        // GET api/<HistoriqueController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Historique historique = this._histoRipository.Get(id);
            if (!(historique is null))
                return Ok(historique);
            else
                return NotFound();
        }

        // POST api/<HistoriqueController>
        [HttpPost]
        public IActionResult Post([FromBody] Historique historique)
        {
            int Success = _histoRipository.Create(historique);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<HistoriqueController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Historique historique)
        {
            this._histoRipository.Update(id, historique);
            return Ok();
        }

        // DELETE api/<HistoriqueController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _histoRipository.Delete(id);
            return Ok(id);
        }
    }
}
