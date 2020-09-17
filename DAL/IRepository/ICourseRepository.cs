using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    public interface ICourseRepository
    {
        void Create(Course NouveauCheval);
        void Delete(int idADelete);
        List<Course> GetallCourses();
        Course Get(int idaChercher);
        void Update(Course ChevalAModifier);
    }
}