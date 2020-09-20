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
            IEnumerable<Employé> employés = _employeRepository.GetallEmploye().Select(x => x);
            if (!(employés is null))

                return Ok(employés);
            else
                return NotFound();
        }

        // GET api/<EmployeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employé employé = this._employeRepository.GetById(id);
            if (!(employé is null))
                return Ok(employé);
            else
                return NotFound();
        }

        // POST api/<EmployeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employé employé)
        {
            int Success = _employeRepository.Create(employé);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<EmployeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employé employé)
        {
            this._employeRepository.Update(id, employé);
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
