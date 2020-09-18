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
    class CourseRepository : ICourseRepository
    {
        private static Connection _connection;

        public CourseRepository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Course> GetallCourses()
        {
            Command command = new Command("SELECT * FROM Course");
            return _connection.ExecuteReader(command, dr => dr.CourseToDal());

        }
        public Course GetById(int id)
        {

            Command command = new Command("SELECT * FROM COURSE where Id_Course = @id");
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
            command.AddParameter("Date_Course", course.Date_Course);
            command.AddParameter("Poids_De_Course", course.Poids_De_Course);
            command.AddParameter("Distance", course.Distance);

            return _connection.ExecuteNonQuery(command);


        }
    

        public int Update( int id, Course course)
        {


                Command command = new Command("UPDATE COURSE SET Hippodrome = @Hippodrome , " +
                                                                          "Jockey = @Jockey" + 
                                                                          "Corde = @Corde , " +
                                                                          "Discipline = @Discipline , " +
                                                                          "Terrain = @Terrain, " +
                                                                          "Avis = @Avis, " +
                                                                          "Date_Course = @Date_Course, " +
                                                                          "Poids_De_Course = @Poids_De_Course, " +
                                                                          "Distance = @Distance " +

                                                                        "WHERE Id_Course = @Id_Course");

                command.AddParameter("Id_Course", course.Id_Course);
                command.AddParameter("Hippodrome", course.Hippodrome);
                command.AddParameter("Jockey", course.Jockey);
                command.AddParameter("Corde", course.Corde);
                command.AddParameter("Discipline", course.Discipline);
                command.AddParameter("Terrain", course.Terrain);
                command.AddParameter("Avis", course.Avis);
                command.AddParameter("Date_Course", course.Date_Course);
                command.AddParameter("Poids_De_Course", course.Poids_De_Course);
                command.AddParameter("Distance", course.Distance);

            return _connection.ExecuteNonQuery(command);

            }
        
        public int Delete(int id)
        {

            Command command = new Command("DELETE FROM Course where Id_Course = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);

            
        }


    }
}


