using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
  public class CourseService
  {
    private mymCourseRepository mymCourseRepository;
    private ChevalRepository chevalRepository;
    private CourseRepository courseRepository;


    public CourseService(mymCourseRepository mymrepo, ChevalRepository chevrepo, CourseRepository courserepo)
    {
      mymCourseRepository = mymrepo;
      chevalRepository = chevrepo;
      courseRepository = courserepo;
    }
    public int createCourse(Course course)
    {
      return courseRepository.Create(course);
    }
    public void associateCourseCheval(int Id_Course, int Id_Cheval)
    {
      MymCourse mymcourse = new MymCourse()
      {
        ChevalId_Cheval = Id_Cheval,
        CoursesId_Course = Id_Course
      };
      if (!(courseRepository.GetById(mymcourse.CoursesId_Course) is null)
        &&
        !(chevalRepository.GetById(mymcourse.CoursesId_Course) is null))

        mymCourseRepository.Create(mymcourse);
    }
  }
}
