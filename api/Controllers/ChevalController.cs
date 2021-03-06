using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Utils.Extensions;
using DAL.IRepository;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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
            IEnumerable<Cheval> chevals = _chevalRepository.Get().Select(x => x.DALChevalToAPI());

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
                return Ok(cheval.DALChevalToAPI());
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
        [HttpGet("{id}/ChevalSoins")]
        public IActionResult GetSoinsByIdCheval(int id)
        {
            IEnumerable<SoinsCheval> soinsChevals = _chevalRepository.SoinsParCheval(id);
            if (soinsChevals is null)
                return NotFound();
            return Ok(soinsChevals);
        }

        [HttpGet("{id}/EntrainementCheval")]
        public IActionResult GetEntrainementParCheval(int id)
        {
            IEnumerable<ChevalEntrainement> chevalEntrainements = _chevalRepository.chevalEntrainements(id);
            if (chevalEntrainements is null)
                return NotFound();
            return Ok(chevalEntrainements);
        }
        [HttpGet ("{id}/EmployeEntraine")]
        public IActionResult GetEmployeEntraineParCheval(int id)
        {
            IEnumerable<EmployeCheval> employeChevals = _chevalRepository.EntrainementEmployeChevals(id);
            if (employeChevals is null)
                return NotFound();
            return Ok(employeChevals);
        }
        [HttpGet("{id}/EmployeSoins")]
        public IActionResult EmployeSoignant(int id)
        {
            IEnumerable<SoinEmployeCheval> soinEmployeChevals = _chevalRepository.soinEmployeChevals(id);
            if (soinEmployeChevals is null)
                return NotFound();
            return Ok(soinEmployeChevals);
        }
        [HttpGet("{id}/ChevalVaccin")]
        public IActionResult VaccinCheval(int id)
        {
            IEnumerable<ChevalVaccination> chevalVaccinations = _chevalRepository.chevalVaccinations(id);
            if (chevalVaccinations is null)
                return NotFound();
            return Ok(chevalVaccinations);
        }
        [HttpGet ("{id}/ChevalCourse")]
        public IActionResult CourseCheval (int id)
        {
            IEnumerable<ChevalCourse> chevalCourses = _chevalRepository.chevalCourses(id);
            if (chevalCourses is null)
                return NotFound();
            return Ok(chevalCourses);

        }
        [HttpGet("{id}/ChevalHistorique")]
        public IActionResult historiqueCheval(int id)
        {
            IEnumerable<ChevalHistorique> chevalHistoriques = _chevalRepository.chevalHistoriques(id);
            if (chevalHistoriques is null)
                return NotFound();
            return Ok(chevalHistoriques);
        }

    }
}
