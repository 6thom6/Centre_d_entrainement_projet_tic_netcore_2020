using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.Models;
using DAL.IRepository;
using Tools.Database;
using DAL.Repository.Extensions;
using System.Linq;

namespace DAL.Repository
{
   public class CourseRepository : ICourseRepository
    {
        private static Connection _connection;

        public CourseRepository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<ChevalCourse> GetallCourses()
        {
            Command command = new Command("SELECT * FROM V_Coursecomplet");
            return _connection.ExecuteReader(command, dr => dr.ChevalCourseToDal());

        }
        public Course GetById(int id)
        {

            Command command = new Command("SELECT * FROM COURSE where Id_Courses = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.CourseToDal()).SingleOrDefault();




        }
        public int Create(Course course)
        {

            Command command = new Command("CreateCourse", true);
            command.AddParameter("Hippodrome", course.Hippodrome);
            command.AddParameter("Jockey", course.Jockey);
            command.AddParameter("Corde", course.Corde);
            command.AddParameter("Discipline", course.Discipline);
            command.AddParameter("Terrain", course.Terrain);
            command.AddParameter("Avis", course.Avis);
            command.AddParameter("Date_Courses", course.Date_Courses);
            command.AddParameter("Poids_De_Course", course.Poids_De_Course);
            command.AddParameter("Distance", course.Distance);

            return _connection.ExecuteNonQuery(command);


        }
    

        public int Update( int id, Course course)
        {


                Command command = new Command("UPDATE COURSE SET Hippodrome = @Hippodrome, " +
                                                                          "Jockey = @Jockey," + 
                                                                          "Corde = @Corde , " +
                                                                          "Discipline = @Discipline, "+
                                                                          "Terrain = @Terrain, " +
                                                                          "Avis = @Avis, "+
                                                                          "Date_Courses = @Date_Courses, "+
                                                                          "Poids_De_Course = @Poids_De_Course, "+
                                                                          "Distance = @Distance " +

                                                                        "WHERE Id_Courses = @Id_Courses");

                command.AddParameter("Id_Courses", id);
                command.AddParameter("Hippodrome", course.Hippodrome);
                command.AddParameter("Jockey", course.Jockey);
                command.AddParameter("Corde", course.Corde);
                command.AddParameter("Discipline", course.Discipline);
                command.AddParameter("Terrain", course.Terrain);
                command.AddParameter("Avis", course.Avis);
                command.AddParameter("Date_Courses", course.Date_Courses);
                command.AddParameter("Poids_De_Course", course.Poids_De_Course);
                command.AddParameter("Distance", course.Distance);
            
            return _connection.ExecuteNonQuery(command);

            }
        
        public int Delete(int id)
        {

            Command command = new Command("DELETE FROM Course where Id_Courses = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);

            
        }


    }
}


