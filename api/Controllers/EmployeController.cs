using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepository;
using DAL.Models;
using DAL.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private IEmployeRepository _employeRepository;

        public EmployeController(EmployeRepository employe)
        {
            _employeRepository = employe;
        }

        // GET: api/<EmployeController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employe> employes = _employeRepository.GetallEmploye().Select(x => x);
            if (!(employes is null))

                return Ok(employes);
            else
                return NotFound();
        }

        // GET api/<EmployeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employe employe = this._employeRepository.GetById(id);
            if (!(employe is null))
                return Ok(employe);
            else
                return NotFound();
        }

        // POST api/<EmployeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employe employe)
        {
            int Success = _employeRepository.Create(employe);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<EmployeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employe employe)
        {
            this._employeRepository.Update(id, employe);
            return Ok();
        }

        // DELETE api/<EmployeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeRepository.Delete(id);
            return Ok(id);
        }
    }
}
