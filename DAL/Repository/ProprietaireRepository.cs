using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;
using Tools.Database;
using DAL.Repository.Extensions;
using System.Linq;

namespace DAL.Repository
{
   public class ProprietaireRepository : IProprietaireRepository
    {
        private static Connection _connection;

        public ProprietaireRepository():this(_connection)
        {

        }
        public ProprietaireRepository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<ProprietaireCheval> proprietaireChevals (int id)
        {
            Command command = new Command("select p.Nom_Proprietaire, p.Date_Arrivee, c.Nom_cheval, c.Pere_cheval, c.Mere_cheval, c.Sortie_provisoire, c.Raison_Sortie, c.Race, c.Age, c.Sexe from Proprietaire P join Cheval C on p.Id_Proprietaire = c.Id_Proprietaire where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.ProprietaireChevalTodDal());
        }
        public IEnumerable<ProprietaireCourse>proprietaireCourses (int id)
        {
            Command command = new Command("select p.Nom_Proprietaire, c.Nom_cheval, co.Distance, co.Hippodrome, co.Jockey, co.Corde, co.Discipline, co.Terrain, co.Avis, co.Poids_De_Course, co. Date_Courses from Proprietaire p join Cheval c on p.Id_Proprietaire = c.Id_Cheval join mym_Course_cheval mym on c.Id_Cheval = c.Id_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p. Id_Proprietaire=@id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.ProprietaireCourseToDal());
        }
        public IEnumerable<ProprietaireCheval> GetallProprietaire()
        {
            Command command = new Command("select p.Nom_Proprietaire, p.Date_Arrivee, c.Nom_cheval, c.Pere_cheval, c.Mere_cheval, c.Sortie_provisoire, c.Raison_Sortie, c.Race, c.Age, c.Sexe from Proprietaire P join Cheval C on p.Id_Proprietaire = c.Id_Proprietaire");
            return _connection.ExecuteReader(command, dr => dr.ProprietaireChevalTodDal());
        }
        public Proprietaire Get(int id)
        {
            Command command = new Command("SELECT * FROM Proprietaire where Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.ProprietaireSimpleToDal()).SingleOrDefault();
        }
        public IEnumerable<SoinsCheval>soinChevals(int id)
        {
            Command command = new Command("select c.Nom_cheval, s.Type_De_Soin, s.Date_De_Soin, s.Durree_Indisponibilite, c.Age, c.Sexe, s.Marechal_Derniere_Visite, s.Vermifuge, s.Alimentation, s.Complement_Alimentation  from Proprietaire p join Cheval c on p.Id_Proprietaire = c. Id_Proprietaire join Soins s on s.Id_Cheval = c.Id_Cheval where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.SoinsChevalToDal());
        }
        public int Create(Proprietaire proprietaire)
        {
            Command command = new Command("CreateProprietaire", true);
                  command.AddParameter("Nom_Proprietaire", proprietaire.Nom_Proprietaire);
                command.AddParameter("Date_Arrivee", proprietaire.Date_Arrivee);

            return _connection.ExecuteNonQuery(command);
        }
        public int Update(int id, Proprietaire proprietaire)
        {



                Command command = new Command ("UPDATE Proprietaire SET Nom_Proprietaire = @Nom_Proprietaire, " +
                                                                        "Date_Arrivee = @Date_Arrivee, "  +
                                                                        "WHERE Id_Proprietaire = @Id_Proprietaire");

                command.AddParameter("Id_Proprietaire", id);
                command.AddParameter("Nom_Proprietaire", proprietaire.Nom_Proprietaire);
                command.AddParameter("Date_Arrivee", proprietaire.Date_Arrivee);

            return _connection.ExecuteNonQuery(command);

            }
        
        public int Delete(int id)
        {

            throw new Exception();
        //Command command = new Command("DELETE FROM Proprietaire where Id_Proprietaire = @id");
        //command.AddParameter("id", id);

        //    return _connection.ExecuteNonQuery(command);
        }
        public Proprietaire ProprietaireParChevalId(int id, Proprietaire proprietaire) 
        {
            Command command = new Command("Select " +
                "                               P.Nom_Proprietaire, " +
                "                               P.Dernier_Resultat, " +
                "                               P.Date_Arrivee " +
                "                           from Proprietaire P join cheval c " +
                "                               on c.Id_Proprietaire = P.Id_Proprietaire" +
                "                              where Id_Cheval = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.ProprietaireSimpleToDal()).SingleOrDefault();
        }
        public string ChevalCouruParProprietaire(int id)
        {
            Command command = new Command("select c.Nom_cheval from Proprietaire p join Cheval c on p.Id_Proprietaire = c.Id_Proprietaire where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command,dr=> (string)dr["Nom_Cheval"]).FirstOrDefault();
        }
        public string DisciplineCourrueParProprio(int id)
        {
            Command command = new Command("select co.Discipline from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Discipline"]).FirstOrDefault();
        }
        public int DistanceParProprio(int id)
        {
            Command command = new Command("select co.Distance from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Distance"]).FirstOrDefault();
        }
        public string HippordromeParProprio (int id)
        {
            Command command = new Command("select co.Hippodrome from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Hippodrome"]).FirstOrDefault();

        }
        public string JockeyParProprio(int id)
        {
            Command command = new Command("select co.Jockey from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Jockey"]).FirstOrDefault();

        }
        public string CordeParProprio(int id)
        {
            Command command = new Command("select co.Corde from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Corde"]).FirstOrDefault();

        }
        public string DisciplineParProprio(int id)
        {
            Command command = new Command("select co.Discipline from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Discipline"]).FirstOrDefault();

        }
        public string TerrainParProprio(int id)
        {
            Command command = new Command("select co.Terrain from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Terrain"]).FirstOrDefault();

        }
        public string AvisParProprio(int id)
        {
            Command command = new Command("select co.Avis from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Avis"]).FirstOrDefault();

        }
        public double Poids_De_CourseParProprio(int id)
        {
            Command command = new Command("select co.Poids_De_Course from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (double)dr["Poids_De_Course"]).FirstOrDefault();

        }
        public DateTime Date_CoursesParProprio(int id)
        {
            Command command = new Command("select co.Poids_De_Course from Proprietaire p join cheval c on p.Id_Proprietaire = c.Id_Proprietaire join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = co.Id_Courses where p.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Date_Courses"]).FirstOrDefault();

        }
        public string ChevauxParProprio (int id)
        {
            Command command = new Command("select c.Nom_cheval from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();

        }
        public string PereChevalParProprio(int id)
        {
            Command command = new Command("select c.Pere_cheval from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Pere_cheval"]).FirstOrDefault();
        }
        public string MereChevalParProprio (int id)
        {
            Command command = new Command("select c.Mere_cheval from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr=>(string)dr["Mere_cheval"]).FirstOrDefault();
        }
        public string SortieProvisoirParProprio(int id)
        {
            Command command = new Command("select c.Sortie_provisoire from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = @id");
            command.AddParameter("id",id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sortie_provisoire"]).FirstOrDefault();
        }
        public string RaisonSortieProviParProprio(int id)
        {
            Command command = new Command("select c.Raison_Sortie from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = 1");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sortie_provisoire"]).FirstOrDefault();

        }
        public string RaceParProprio(int id)
        {
            Command command = new Command("select c.Race from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = 1");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Race"]).FirstOrDefault();

        }
        public int AgeChevauxParProprio (int id)
        {
            Command command = new Command("select c.Age from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = 1");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Race"]).FirstOrDefault();

        }
        public string SexeChevParProprio (int id)
        {
            Command command = new Command("select c.Sexe from Proprietaire P join Cheval C on P.Id_Proprietaire = c.Id_Proprietaire where c.Id_Proprietaire = 1");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sexe"]).FirstOrDefault();

        }
    }
}
