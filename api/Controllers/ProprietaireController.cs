using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.IRepository;
using DAL.Models;
using DAL.Repository;
using api.Models;
using api.Utils.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietaireController : ControllerBase
    {
        private IProprietaireRepository _proprietaireRipository;

        public ProprietaireController (ProprietaireRepository proprietaire)
        {
            _proprietaireRipository = proprietaire;
        }
           

        // GET: api/<ProprietaireController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ProprietaireSimpleAPI> proprietaires = _proprietaireRipository.GetallProprietaire().Select(x => x.DALProprietaireSimpleToAPI());
            if (!(proprietaires is null))
                return Ok(proprietaires);
            else
                return NotFound();
       
        }

        // GET api/<ProprietaireController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Proprietaire proprietaire = this._proprietaireRipository.Get(id);
            if (!(proprietaire is null))
                return Ok(proprietaire.DALProprietaireChevalToAPI());
            else
                return NotFound();
        }

        // POST api/<ProprietaireController>
        [HttpPost]
        public IActionResult Post([FromBody] Proprietaire proprietaire)
        {
            int Success = _proprietaireRipository.Create(proprietaire);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }
        
        

        // PUT api/<ProprietaireController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Proprietaire proprietaire)
        {
            this._proprietaireRipository.Update(id, proprietaire);
            return Ok();
        }

        // DELETE api/<ProprietaireController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _proprietaireRipository.Delete(id);
            return Ok(id);
        }
        [HttpGet("{id}/ProprietaireEffectif")]
        public IActionResult EffectifParProprio(int id)
        {
            IEnumerable<ProprietaireCheval> proprietaireChevals = _proprietaireRipository.proprietaireChevals(id);
            if (proprietaireChevals is null)
                return NotFound();
            return Ok(proprietaireChevals);
        }
        [HttpGet("{id}/ProprietaireCourses")]
        public IActionResult CoursesParProprio(int id)
        {
            IEnumerable<ProprietaireCourse> proprietaireCourses = _proprietaireRipository.proprietaireCourses(id);
            if (proprietaireCourses is null)
                return NotFound();
            return Ok(proprietaireCourses);
        }
    }
}
