using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepository
{
  interface ImymCourseRepository
  {
    int Create(MymCourse mymCourse);
  }
}
