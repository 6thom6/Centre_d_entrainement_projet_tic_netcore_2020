using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepository;
using api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrainementController : ControllerBase

    {
        private IEntrainementRepository _entrainementRepository;
        private IEmployeRepository _employeRepository;

        public EntrainementController(EntrainementRepository entrainement, EmployeRepository employeRepository)
        {
            _entrainementRepository = entrainement;
            this._employeRepository = employeRepository;

        }
        // GET: api/<EntrainementController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Entrainement> entrainements = _entrainementRepository.GetallEntrainement().Select(x => x);
            if (!(entrainements is null))
                return Ok(entrainements);
            else
                return NotFound();
        }

        [HttpGet("{id}/employeCheval")]
        public IActionResult GetAllEmployeByEntrainementId(int id)
        {
            IEnumerable<Employe> employeChevals = _entrainementRepository.GetAllEmployeByEntrainementId(id);

            if (employeChevals is null) return NotFound();

            return Ok(employeChevals);
        }
        [HttpGet("{id}/Employe")]
        public IActionResult GetAllEmployeAndChevalByEntrainementId(int id)
        {
            IEnumerable<EmployeCheval> employes = _entrainementRepository.GetAllEmployeAndChevalByEntrainementId(id);

            if (employes is null)
                return NotFound();
            return Ok(employes);
        }



        // GET api/<EntrainementController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Entrainement entrainement = this._entrainementRepository.GetById(id);
            if (!(entrainement is null))
                return Ok(entrainement);
            else
                return NotFound();
        }

        // POST api/<EntrainementController>
        [HttpPost]
        public IActionResult Post([FromBody] Entrainement entrainement)
        {
            int Success = _entrainementRepository.Create(entrainement);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<EntrainementController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entrainement entrainement)
        {
            this._entrainementRepository.Update(id, entrainement);
            return Ok();
        }

        // DELETE api/<EntrainementController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _entrainementRepository.Delete(id);
            return Ok();
        }
    }

}
