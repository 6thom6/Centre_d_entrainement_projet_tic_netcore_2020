using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.Models;
using DAL.IRepository;

namespace DAL.Repository
{
    class CourseRepository : ICourseRepository
    {
        public SqlConnection _connection;

        public CourseRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        public List<Course> GetallCourses()
        {
            List<Course> GetallCourses = new List<Course>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM COURSE", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallCourses.Add(
                        new Course
                        {
                            Id_Course = (int)reader["Id_Course"],
                            Hippodrome = (string)reader["Hippodrome"],
                            Jockey = (string)reader["Jockey"],
                            Corde = (string)reader["Corde"],
                            Discipline = (string)reader["Discipline"],
                            Terrain = (string)reader["Terrain"],
                            Poids_De_Course = (float) reader["Poids_De_Course"],
                            Avis = reader["Avis"] == DBNull.Value ? null : (string)reader["Avis"],
                            Date_Course = (DateTime)reader["Date_Course"],
                            Distance = (int) reader["Distance"],


                        }
                        ) ;
                }
            }

            return GetallCourses;
        }
        public Course Get(int idAChercher)
        {

            Course GetCourses = new Course();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM COURSE where id =@idCherch", _connection);
                    command.Parameters.AddWithValue("idCherch", idAChercher);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Course
                    {
                        Id_Course = (int)reader["Id_Course"],
                        Hippodrome = (string)reader["Hippodrome"],
                        Jockey = (string)reader["Jockey"],
                        Corde = (string)reader["Corde"],
                        Discipline = (string)reader["Discipline"],
                        Terrain = (string)reader["Terrain"],
                        Poids_De_Course = (float)reader["Poids_De_Course"],
                        Avis = reader["Avis"] == DBNull.Value ? null : (string)reader["Avis"],
                        Date_Course = (DateTime)reader["Date_Course"],
                        Distance = (int)reader["Distance"],

                    };
             
                }
                return GetCourses;

            }


        }
        public void Create(Course NouvelleCourse)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO COURSE (Hippodrome," +
                                                                        "Jockey," + //les champs de la table
                                                                        "Corde," +
                                                                        "Discipline," +
                                                                        "Terrain," +
                                                                        "Avis," +
                                                                        "Date_Course," +
                                                                        "Poids_De_Course," +
                                                                        "Distance)" +

                                                     "VALUES            (@Hippodrome, " +
                                                                        "@Jockey," + //les champs a rentrer
                                                                        "@Corde, " +
                                                                        "@Discipline, " +
                                                                        "@Terrain, " +
                                                                        "@Avis, " +
                                                                        "@Date_Course," +
                                                                        "@Poids_De_Course, " +
                                                                        "@Distance)");

                command.Parameters.AddWithValue("Hippodrome", NouvelleCourse.Hippodrome);
                command.Parameters.AddWithValue("Jockey", NouvelleCourse.Jockey);
                command.Parameters.AddWithValue("Corde", NouvelleCourse.Corde);
                command.Parameters.AddWithValue("Discipline", NouvelleCourse.Discipline);
                command.Parameters.AddWithValue("Terrain", NouvelleCourse.Terrain);
                command.Parameters.AddWithValue("Avis", NouvelleCourse.Avis);
                command.Parameters.AddWithValue("Date_Course", NouvelleCourse.Date_Course);
                command.Parameters.AddWithValue("Poids_De_Course", NouvelleCourse.Poids_De_Course);
                command.Parameters.AddWithValue("Distance", NouvelleCourse.Distance);

                command.ExecuteNonQuery();



                _connection.Close();
            }
        }
        public void Update(Course CourseAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE COURSE" + "SET Hippodrome = @Hippodrome , " +
                                                                          "Jockey = @Jockey" + 
                                                                          "Corde = @Corde , " +
                                                                          "Discipline = @Discipline , " +
                                                                          "Terrain = @Terrain, " +
                                                                          "Avis = @Avis, " +
                                                                          "Date_Course = @Date_Course, " +
                                                                          "Poids_De_Course = @Poids_De_Course, " +
                                                                          "Distance = @Distance " +

                                                                        "WHERE Id_Course = @Id_Course");

                command.Parameters.AddWithValue("Id_course", CourseAModifier.Id_Course);
                command.Parameters.AddWithValue("Hippodrome", CourseAModifier.Hippodrome);
                command.Parameters.AddWithValue("Jockey", CourseAModifier.Jockey);
                command.Parameters.AddWithValue("Corde", CourseAModifier.Corde);
                command.Parameters.AddWithValue("Discipline", CourseAModifier.Discipline);
                command.Parameters.AddWithValue("Terrain", CourseAModifier.Terrain);
                command.Parameters.AddWithValue("Avis", CourseAModifier.Avis);
                command.Parameters.AddWithValue("Date_Course", CourseAModifier.Date_Course);
                command.Parameters.AddWithValue("Poids_De_Course", CourseAModifier.Poids_De_Course);
                command.Parameters.AddWithValue("Distance", CourseAModifier.Distance);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {
        
                using (_connection)
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM COURSE where Id = @id");
                    command.Parameters.AddWithValue("id", idADelete);
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            
        }
    }
}


