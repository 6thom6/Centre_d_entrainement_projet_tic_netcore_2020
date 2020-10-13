using DAL.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Database;

namespace DAL.Repository
{
  public class mymCourseRepository : ImymCourseRepository
  {
    private Connection _Connection;

    public mymCourseRepository(Connection connection)
    {
      _Connection = connection;
    }

    public int Create (MymCourse mymCourse)
    {
      Command command = new Command("insert into mym_Course_cheval values (@Id_Cheval, @Id_Course)");
      command.AddParameter("Id_Cheval", mymCourse.ChevalId_Cheval);
      command.AddParameter("Id_Course", mymCourse.CoursesId_Course);

      return _Connection.ExecuteNonQuery(command);

    }
  }

}
