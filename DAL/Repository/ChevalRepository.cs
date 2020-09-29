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

        public ChevalRepository() : this(_connection)
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
        public string GetPlatParCheval(int id)
        {
            Command command = new Command(" select E.Plat from Cheval C join Participe_Entrainement_cheval_employé PECE on C.Id_Cheval = PECE.Id_Cheval join Entrainement E on E.Id_Entrainement = PECE.Id_Entrainement where C.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Plat"]).FirstOrDefault();
        }
        public string GetObstacleParCheval(int id)
        {
            Command command = new Command(" select E.Obstacle from Cheval C join Participe_Entrainement_cheval_employé PECE on C.Id_Cheval = PECE.Id_Cheval join Entrainement E on E.Id_Entrainement = PECE.Id_Entrainement where C.Id_Cheval=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Obstacle"]).FirstOrDefault();
        }
        public string GetMarcheurParCheval(int id)
        {
            Command command = new Command(" select E.Marcheur from Cheval C join Participe_Entrainement_cheval_employé PECE on C.Id_Cheval = PECE.Id_Cheval join Entrainement E on E.Id_Entrainement = PECE.Id_Entrainement where C.Id_Cheval=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Marcheur"]).FirstOrDefault();
        }
        public string GetPreParCheval(int id)
        {
            Command command = new Command(" select E.Pre from Cheval C join Participe_Entrainement_cheval_employé PECE on C.Id_Cheval = PECE.Id_Cheval join Entrainement E on E.Id_Entrainement = PECE.Id_Entrainement where C.Id_Cheval=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Pre"]).FirstOrDefault();
        }
        public string GetDureeParCheval(int id)
        {
            Command command = new Command(" select E.Duree from Cheval C join Participe_Entrainement_cheval_employé PECE on C.Id_Cheval = PECE.Id_Cheval join Entrainement E on E.Id_Entrainement = PECE.Id_Entrainement where C.Id_Cheval=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Duree"]).FirstOrDefault();
        }
        public DateTime GetDateEntrainementParCheval(int id)
        {
            Command command = new Command(" select E.Date_Entrainement from Cheval C join Participe_Entrainement_cheval_employé PECE on C.Id_Cheval = PECE.Id_Cheval join Entrainement E on E.Id_Entrainement = PECE.Id_Entrainement where C.Id_Cheval=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Date_Entrainement"]).FirstOrDefault();
        }
        public DateTime GetDateCourseParCheval(int id)
        {
            Command command = new Command(" select c.Date_Courses from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Date_Courses"]).FirstOrDefault();
        }
        public DateTime GetDateSoinsParCheval(int id)
        {
            Command command = new Command(" select S.Date_De_Soin from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Date_De_Soin"]).FirstOrDefault();
        }
        public DateTime GetDateVermifugeParCheval(int id)
        {
            Command command = new Command(" select S.Vermifuge from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Vermifuge"]).FirstOrDefault();
        }
        public DateTime GetDateMarechalParCheval(int id)
        {
            Command command = new Command(" select S.Marechal_Derniere_Visite from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Marechal_Derniere_Visite"]).FirstOrDefault();
        }
        public string GetTypeDeSoinsParCheval(int id)
        {
            Command command = new Command(" select S.Type_De_Soin from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Type_De_Soin"]).FirstOrDefault();
        }
        public string GetNoteLibreDeSoinsParCheval(int id)
        {
            Command command = new Command(" select S.Note_Libre from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Note_Libre"]).FirstOrDefault();
        }
        public string GetAlimentationParCheval(int id)
        {
            Command command = new Command(" select S.Alimentation from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Alimentation"]).FirstOrDefault();
        }
        public string GetComplementAlimentationParCheval(int id)
        {
            Command command = new Command(" select S.Complement_Alimentation from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Complement_Alimentation"]).FirstOrDefault();
        }
        public string GetDureeIndisponibiliteParCheval(int id)
        {
            Command command = new Command(" select S.Durree_Indisponibilite from Soins S join Cheval C on S.Id_Cheval = C.Id_Cheval where c.Id_Cheval =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Durree_Indisponibilite"]).FirstOrDefault();
        }



        public string GetHippodromeCourseParCheval(int id)
        {
            Command command = new Command(" select c.Hippodrome from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Hippodrome"]).FirstOrDefault();
        }

        public int GetIdCourseParCheval(int id)
        {
            Command command = new Command(" select c.Id_Courses from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Id_Courses"]).FirstOrDefault();
        }
        public string GetCordeCourseParCheval(int id)
        {
            Command command = new Command(" select c.Corde from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Corde"]).FirstOrDefault();
        }
        public int GetDistanceCourseParCheval(int id)
        {
            Command command = new Command(" select c.Distance from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Distance"]).FirstOrDefault();
        }
        public string GetDisciplineCourseParCheval(int id)
        {
            Command command = new Command(" select c.Distance from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Distance"]).FirstOrDefault();
        }
        public string GetTerrainCourseParCheval(int id)
        {
            Command command = new Command(" select c.Terrain from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Terrain"]).FirstOrDefault();

        }
        public string GetAvisCourseParCheval(int id)
        {
            Command command = new Command(" select c.Avis from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Avis"]).FirstOrDefault();

        }
        public string GetJockeyParCheval(int id)
        {
            Command command = new Command(" select c.Jockey from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Jockey"]).FirstOrDefault();

        }
        public float GetPoidsDeCourseParCheval(int id)
        {
            Command command = new Command(" select c.Poids_De_Course from Cheval CH join mym_Course_cheval mym on ch.Id_Cheval = mym.ChevalId_Cheval join Course c on mym.CoursesId_Course = c.Id_Courses where ch.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (float)dr["Poids_De_Course"]).FirstOrDefault();

        }
        public DateTime GetDelaiVaccinParCheval(int id)
        {
            Command command = new Command("select v.Delai_Indisponibilite from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where c.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Delai_Indisponibilite"]).FirstOrDefault();

        }
        public string GetVaccinParCheval(int id)
        {
            Command command = new Command("select v.Nom_vaccin from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where c.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_vaccin"]).FirstOrDefault();

        }
        public int GetIDVaccinParCheval(int id)
        {
            Command command = new Command("select v.Id_vaccination from Vaccination V join mym_Vaccination_Cheval mym on V.Id_vaccination = mym.Id_Vaccination join Cheval c on c.Id_Cheval = mym.Id_Cheval where c.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Id_vaccination"]).FirstOrDefault();

        }

        public string GetElevageCheval(int id)
        {
            Command command = new Command(" select h.Elevage from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Elevage"]).FirstOrDefault();
        }
        public string GetProprietaire_PrecedentCheval(int id)
        {
            Command command = new Command("select h.Proprietaire_precedent from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Proprietaire_precedent"]).FirstOrDefault();
        }
        public string GetDebourrageChevalParHisto(int id)
        {
            Command command = new Command(" select h.Debourage from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Debourage"]).FirstOrDefault();
        }
        public string GetPre_EntrainementChevalParHisto(int id)
        {
            Command command = new Command(" select h.Pre_Entrainement from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Pre_Entrainement"]).FirstOrDefault();
        }
        public string GetEntraineur_PrecedentChevalParHisto(int id)
        {
            Command command = new Command(" select h.Entraineur_precedent from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Entraineur_precedent"]).FirstOrDefault();
        }
        public int Create(Cheval cheval)
        {
            Command command = new Command("CreateCheval", true);
            command.AddParameter("Nom_Cheval", cheval.Nom_Cheval);
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
            command.AddParameter("Nom_Cheval", cheval.Nom_Cheval);
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

            return _connection.ExecuteReader(command, dr => dr.ProprietaireSimpleToDal()).SingleOrDefault();
        }

















        //Pas restfull, lourd, pas opti, déception 23244, l'interface sera de la daube


        //public IEnumerable<Entrainement> GetAllEntrainementById(int id)
        //{
        //    Command command = new Command("SELECT E.Date_Entrainement," +
        //        "                                 E.Plat," +
        //        "                                 E.Obstacle," +
        //        "                                 E.Marcheur," +
        //        "                                 E.Duree," +
        //        "                                 E.Pre," +
        //        "                                 E.Id_Entrainement " +
        //        "                           FROM Cheval C JOIN Participe_Entrainement_cheval_employé CE" +
        //        "                                   ON C.Id_Cheval = CE.Id_Cheval " +
        //        "                                 JOIN Entrainement E " +
        //        "                                   ON CE.Id_Entrainement = E.Id_Entrainement " +
        //        "                           WHERE C.Id_Cheval = @id");
        //    command.AddParameter("id", id);

        //    return _connection.ExecuteReader(command, dr => dr.EntrainementToDal());
        //}

        //public IEnumerable<Course> GetallCoursesById(int id)
        //{
        //    Command commande = new Command("select Date_Courses, " +
        //        "                                  Hippodrome, " +
        //        "                                  Discipline, " +
        //        "                                  Distance, " +
        //        "                                  Jockey, " +
        //        "                                  Poids_De_Course, " +
        //        "                                  Terrain, " +
        //        "                                  Corde, " +
        //        "                                  Avis," +
        //        "                                  Id_Courses " +
        //        "                              from Course c join mym_Course_cheval m" +
        //        "                                     on m.CoursesId_Course = c.Id_Courses" +
        //        "                              where m.ChevalId_Cheval = @id");
        //    commande.AddParameter("id", id);

        //    return _connection.ExecuteReader(commande, dr => dr.CourseToDal());
        //}
        //public IEnumerable<Employe> GetAllEmployeById(int id)
        //{
        //    Command command = new Command("select E.Nom_Employe," +
        //        "                                 E.Id_Employe, " +
        //        "                                 E.Statuts_Employe," +
        //        "                                 E.Date_Embauche " +
        //        "                             FROM Cheval C join Participe_Entrainement_cheval_employé PE       " +
        //        "                                   ON C.Id_Cheval = PE.Id_Cheval " +
        //        "                                 join Employe E " +
        //        "                                   ON PE.Id_Employe = E.Id_Employe " +
        //        "                             where C.Id_Cheval = @id");
        //    command.AddParameter("id", id);

        //    return _connection.ExecuteReader(command, dr => dr.EmployeToDal());
        //}
        //public IEnumerable<Soins> GetAllSoinsById(int id)
        //{
        //    Command command = new Command("select C.Nom_cheval, " +
        //        "                                 S.Alimentation, " +
        //        "                                 S.Complement_Alimentation, " +
        //        "                                 S.Marechal_Derniere_Visite, " +
        //        "                                 S.Vermifuge, " +
        //        "                                 S.Date_De_Soin, " +
        //        "                                 S.Type_De_Soin, " +
        //        "                                 E.Nom_Employe, " +
        //        "                                 S.Durree_Indisponibilite, " +
        //        "                                 S.Note_Libre, " +
        //        "                                 S.Id_Cheval, " +
        //        "                                 S.Id_Employe, " +
        //        "                                 S.Id_Soins" +
        //        "                           from Soins S join Employe E" +
        //        "                                   on E.Id_Employe = S.Id_Employe" +
        //        "                                 join Cheval C" +
        //        "                                   on C.Id_Cheval = S.Id_Cheval" +
        //        "                           where C.Id_Cheval = @id");
        //    command.AddParameter("id", id);
        //    return _connection.ExecuteReader(command, dr => dr.SoinsToDAl());
        //}
        //public IEnumerable<Vaccination> GetAllVaccinationsById(int id)
        //{
        //    Command command = new Command("select C.Nom_cheval, " +
        //        "                                 V.Nom_vaccin, " +
        //        "                                 V.Delai_Indisponibilite, " +
        //        "                                 V.Id_vaccination " +
        //        "                          from Vaccination V join mym_Vaccination_Cheval VC" +
        //        "                                   on V.Id_vaccination = VC.Id_Vaccination" +
        //        "                                 join Cheval C" +
        //        "                                   on C.Id_Cheval = VC.Id_Cheval" +
        //        "                          where C.Id_Cheval = @id");
        //    command.AddParameter("id", id);
        //    return _connection.ExecuteReader(command, dr => dr.VaccinationToDal());
        //}

        //public Historique Gethistorique(int id)
        //{
        //    Command command = new Command("Select H.Debourage, " +
        //        "                                  H.Pre_Entrainement, " +
        //        "                                  H.Entraineur_precedent, " +
        //        "                                  H.Proprietaire_precedent, " +
        //        "                                  H.Id_Cheval, " +
        //        "                                  H.Id_historique, " +
        //        "                                  H.Elevage " +
        //        "                           from Historique H" +
        //        "                                 join Cheval C" +
        //        "                                   on H.Id_Cheval = C.Id_Cheval   " +
        //        "                            where C.Id_Cheval = @id");
        //    command.AddParameter("id", id);
        //    return _connection.ExecuteReader(command, dr => dr.HistoriqueToDal()).SingleOrDefault();


        //}
    }
}

