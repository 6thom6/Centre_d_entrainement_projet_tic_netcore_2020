using DAL.Models;
using System.Collections.Generic;
using DAL.IRepository;
using Tools.Database;
using DAL.Repository.Extensions;
using System.Linq;
using System;

namespace DAL.Repository
{
    public class ChevalRepository : IChevalRepository
    {
        private static Connection _connection;

        public ChevalRepository(Connection connection)
        {
            _connection = connection;
        }

        public ChevalRepository(): this(_connection)
        {
        }

        public IEnumerable<Cheval> Get()
        {
            Command command = new Command("SELECT * FROM Cheval");

            return _connection.ExecuteReader(command, dr => dr.ChevalToDAL());
        }

        public Cheval GetById(int id)
        {
            Command command = new Command("SELECT * FROM CHEVAL where ID_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.ChevalToDAL()).SingleOrDefault();
        }

        public Proprietaire GetProprietaire(object id_Proprietaire)
        {
            throw new NotImplementedException();
        }

        public int Create(Cheval cheval)
        {
            Command command = new Command("CreateCheval", true);
            command.AddParameter("Nom_Cheval", cheval.NomCheval);
            command.AddParameter("Pere_Cheval", cheval.PereCheval);
            command.AddParameter("Mere_Cheval", cheval.MereCheval);
            command.AddParameter("Sortie_Provisoire", cheval.SortieProvisoire);
            command.AddParameter("Raison_Sortie", cheval.RaisonSortie);
            command.AddParameter("Id_Proprietaire", cheval.Id_Proprietaire);
            command.AddParameter("Id_Soins", cheval.Id_Soins);
            command.AddParameter("Poids", cheval.Poids);
            command.AddParameter("Race", cheval.Race);
            command.AddParameter("Age", cheval.Age);
            command.AddParameter("Sexe", cheval.Sexe);

            return _connection.ExecuteNonQuery(command);
        }


        public int Update(int id, Cheval cheval)
        {
            Command command = new Command("UPDATE CHEVAL SET Nom_cheval= @Nom_Cheval, " +
                                                                   "Pere_Cheval= @Pere_Cheval, " +
                                                                   "Mere_Cheval=@Mere_Cheval," +
                                                                   "Sortie_Provisoire = @Sortie_Provisoire, " +
                                                                   "Raison_Sortie = @Raison_Sortie," +
                                                                   "Id_Proprietaire = @Id_Proprietaire, " +
                                                                   "Id_Soins = @Id_soins, " +
                                                                   "Poids = @Poids, " +
                                                                   "Race = @Race," +
                                                                   "Age = @Age, " +
                                                                   "Sexe = @Sexe " +
                                                 "WHERE Id_Cheval = @Id_cheval");
            command.AddParameter("Id_Cheval", id);
            command.AddParameter("Nom_Cheval", cheval.NomCheval);
            command.AddParameter("Pere_Cheval", cheval.PereCheval);
            command.AddParameter("Mere_Cheval", cheval.MereCheval);
            command.AddParameter("Sortie_Provisoire", cheval.SortieProvisoire);
            command.AddParameter("Raison_Sortie", cheval.RaisonSortie);
            command.AddParameter("Id_proprietaire", cheval.Id_Proprietaire);
            command.AddParameter("Id_soins", cheval.Id_Soins);
            command.AddParameter("Poids", cheval.Poids);
            command.AddParameter("Race", cheval.Race);
            command.AddParameter("Age", cheval.Age);
            command.AddParameter("Sexe", cheval.Sexe);

            return _connection.ExecuteNonQuery(command);
        }

        public int Delete(int id)
        {
            Command command = new Command("DELETE FROM CHEVAL where Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);
        }

        public Proprietaire GetProprietaire(int id)
        {
            Command command = new Command("SELECT P.Nom_Proprietaire, " +
                "                                 P.Dernier_Resultat, " +
                "                                 P.Id_Proprietaire, " +
                "                                 P.Date_Arrivee " +
                "                          FROM Cheval C JOIN Proprietaire P" +
                "                               ON C.Id_Proprietaire = P.Id_Proprietaire" +
                "                           WHERE C.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.ProprietaireToDal()).SingleOrDefault();
        }

        public IEnumerable<Entrainement> GetAllEntrainementById(int id)
        {
            Command command = new Command("SELECT E.Date_Entrainement," +
                "                                 E.Plat," +
                "                                 E.Obstacle," +
                "                                 E.Marcheur," +
                "                                 E.Duree," +
                "                                 E.Pre," +
                "                                 E.Id_Entrainement " + 
                "                           FROM Cheval C JOIN Participe_Entrainement_cheval_employé CE" +
                "                                   ON C.Id_Cheval = CE.Id_Cheval " +
                "                                 JOIN Entrainement E " +
                "                                   ON CE.Id_Entrainement = E.Id_Entrainement " +
                "                           WHERE C.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EntrainementToDal());
        }

        public IEnumerable<Course> GetallCoursesById(int id)
        {
            Command commande = new Command("select Date_Courses, " +
                "                                  Hippodrome, " +
                "                                  Discipline, " +
                "                                  Distance, " +
                "                                  Jockey, " +
                "                                  Poids_De_Course, " +
                "                                  Terrain, " +
                "                                  Corde, " +
                "                                  Avis," +
                "                                  Id_Courses " +
                "                              from Course c join mym_Course_cheval m" +
                "                                     on m.CoursesId_Course = c.Id_Courses" +
                "                              where m.ChevalId_Cheval = @id");
            commande.AddParameter("id", id);

            return _connection.ExecuteReader(commande, dr => dr.CourseToDal());
        }
        public IEnumerable<Employe> GetAllEmployeById(int id)
        {
            Command command = new Command("select E.Nom_Employe," +
                "                                 E.Id_Employe, " +
                "                                 E.Statuts_Employe," +
                "                                 E.Date_Embauche " + 
                "                             FROM Cheval C join Participe_Entrainement_cheval_employé PE       " +
                "                                   ON C.Id_Cheval = PE.Id_Cheval " +
                "                                 join Employe E " +
                "                                   ON PE.Id_Employe = E.Id_Employe " +
                "                             where C.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EmployeToDal());
        }
        public IEnumerable<Soins> GetAllSoinsById(int id)
        {
            Command command = new Command("select C.Nom_cheval, " +
                "                                 S.Alimentation, " +
                "                                 S.Complement_Alimentation, " +
                "                                 S.Marechal_Derniere_Visite, " +
                "                                 S.Vermifuge, " +
                "                                 S.Date_De_Soin, " +
                "                                 S.Type_De_Soin, " +
                "                                 E.Nom_Employe, " +
                "                                 S.Durree_Indisponibilite, " +
                "                                 S.Note_Libre, " +
                "                                 S.Id_Cheval, " +
                "                                 S.Id_Employe, " +
                "                                 S.Id_Soins" +
                "                           from Soins S join Employe E" +
                "                                   on E.Id_Employe = S.Id_Employe" +
                "                                 join Cheval C" +
                "                                   on C.Id_Cheval = S.Id_Cheval" +
                "                           where C.Id_Cheval = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.SoinsToDAl());
        }
        public IEnumerable<Vaccination> GetAllVaccinationsById(int id)
        {
            Command command = new Command("select C.Nom_cheval, " +
                "                                 V.Nom_vaccin, " +
                "                                 V.Delai_Indisponibilite, " +
                "                                 V.Id_vaccination " +
                "                          from Vaccination V join mym_Vaccination_Cheval VC" +
                "                                   on V.Id_vaccination = VC.Id_Vaccination" +
                "                                 join Cheval C" +
                "                                   on C.Id_Cheval = VC.Id_Cheval" +
                "                          where C.Id_Cheval = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.VaccinationToDal());
        }

        public Historique Gethistorique (int id)
        {
            Command command = new Command("Select H.Debourage, " +
                "                                  H.Pre_Entrainement, " +
                "                                  H.Entraineur_precedent, " +
                "                                  H.Proprietaire_precedent, " +
                "                                  H.Id_Cheval, " +
                "                                  H.Id_historique, " +
                "                                  H.Elevage " +
                "                           from Historique H" +
                "                                 join Cheval C" +
                "                                   on H.Id_Cheval = C.Id_Cheval   " +
                "                            where C.Id_Cheval = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.HistoriqueToDal()).SingleOrDefault();
        }

    }
}
