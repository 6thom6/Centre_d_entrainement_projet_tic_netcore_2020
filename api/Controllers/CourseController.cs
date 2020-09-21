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
    public class CourseController : ControllerBase
        
    {
        private ICourseRepository _courseRepository;

        public CourseController (CourseRepository course)
        {
            _courseRepository = course;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Course> courses = _courseRepository.GetallCourses().Select(x => x);
            if (!(courses is null))
                return Ok(courses);
            else
                return NotFound();
        }

        // GET api/course/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Course course = this._courseRepository.GetById(id);
            if (!(course is null))
                return Ok(course);
            else
                return NotFound();
        }

        // POST api/<CourseController>
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            int Success = _courseRepository.Create(course);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course course)
        {
            this._courseRepository.Update(id, course);
            return Ok();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);

            return Ok(id);
        }
    }
}
