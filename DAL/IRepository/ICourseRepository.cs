using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    public interface ICourseRepository
    {
        Course GetById(int idaChercher);
        int Create(Course NouveauCheval);
        int Update(int id, Course Cheval); 
        int Delete(int id);
        IEnumerable<ChevalCourse> GetallCourses();
  }
}
