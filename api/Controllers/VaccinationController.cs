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
    public class VaccinationController : ControllerBase
    {

        private IVaccinationRepository _vaccinationRepository;

        public VaccinationController(VaccinationRepository vaccination)
        {
            _vaccinationRepository = vaccination;
        }
        // GET: api/<VaccinationController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Vaccination> vaccinations = _vaccinationRepository.GetallVaccination().Select(x => x);
            if (!(vaccinations is null))
                return Ok(vaccinations);
            else
                return NotFound();
                    
        }

        // GET api/<VaccinationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Vaccination vaccination = this._vaccinationRepository.GetById(id);
            if (!(vaccination is null))
                return Ok(vaccination);
            else
                return NotFound();
        }

        // POST api/<VaccinationController>
        [HttpPost]
        public IActionResult Post([FromBody] Vaccination vaccination)
        {
           int Success =  this._vaccinationRepository.Create(vaccination);
            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<VaccinationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vaccination vaccination)
        {
            this._vaccinationRepository.Update(id, vaccination);
            return Ok();
        }

        // DELETE api/<VaccinationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vaccinationRepository.Delete(id);
            return Ok(id);
        }
    }
}
