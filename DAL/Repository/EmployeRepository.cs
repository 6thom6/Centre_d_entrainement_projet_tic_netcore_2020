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
   public class EmployeRepository : IEmployeRepository
    {
        private static Connection _connection;

        public EmployeRepository(Connection connection)
        {
            _connection = connection;
        }

        public EmployeRepository(): this(_connection)
        {

        }
        public IEnumerable<Employe> GetallEmploye()
        {
            Command command = new Command("SELECT * FROM Employe");
            return _connection.ExecuteReader(command, dr => dr.EmployeToDal());
        }

        public Employe GetById(int id)
        {
            Command command = new Command("SELECT * FROM Employe where Id_Employe=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EmployeToDal()).SingleOrDefault();

        }
        public int Create(Employe employe)
        {
            Command command = new Command("CreateEmploye", true);
                command.AddParameter("Nom_Employe", employe.Nom_Employe);
                command.AddParameter("Statuts_Employe", employe.Statuts_Employe);
                command.AddParameter("Date_Embauche", employe.Date_Embauche);
            return _connection.ExecuteNonQuery(command);
            
        }
        public int Update(int id, Employe employe)
        {
            

               Command command = new Command("UPDATE Employe " +
                                                     "SET Nom_Employe = @Nom_Employe, " +
                                                     "Statuts_Employe = @Statuts_Employe, " +
                                                     "Date_Embauche = @Date_Embauche " +
                                                     "where Id_Employe = @Id_Employe");

                command.AddParameter("Id_Employe", id);
                command.AddParameter("Nom_Employe", employe.Nom_Employe);
                command.AddParameter("Statuts_Employe", employe.Statuts_Employe);
                command.AddParameter("Date_Embauche", employe.Date_Embauche);

            return _connection.ExecuteNonQuery(command);

  
        }
        public int Delete(int id)
        {
            throw new Exception();
            //Command command = new Command("DELETE FROM Employe where Id_Employe = @id");
            //command.AddParameter("id", id);

            //return _connection.ExecuteNonQuery(command);
        }
        public IEnumerable<Entrainement> GetAllEntrainementById(int id)
        {
            Command command = new Command("select E.Nom_Employe, " +
                "                                 C.Nom_cheval, " +
                "                                 ENT.Date_Entrainement, " +
                "                                 ENT.Obstacle, " +
                "                                 ENT.Plat, " +
                "                                 ENT.Marcheur, " +
                "                                 ENT.Pre, " +
                "                                 ENT.Duree, " +
                "                                 E.Statuts_Employe, " +
                "                                 E.Date_Embauche," +
                "                                 ENT.Id_Entrainement" +
                " " +
                "                          from Cheval C join Participe_Entrainement_cheval_employé PEC" +
                "                                       on C.Id_Cheval = PEC.Id_Cheval" +
                "                                 join Employe E" +
                "                                       on PEC.Id_Employe = E.Id_Employe" +
                "                                 join Entrainement ENT" +
                "                                       on ENT.Id_Entrainement = PEC.Id_Entrainement" +
                "                           where E.Id_Employe = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EntrainementToDal());
        }
        public IEnumerable<Soins> GetAllSoinsById(int id)
        {
            //nom cheval?!lkjhf&
            Command command = new Command("select C.Nom_cheval, " +
                "                                 S.Alimentation, " +
                "                                 S.Complement_Alimentation, " +
                "                                 S.Marechal_Derniere_Visite," +
                "                                 S.Vermifuge, " +
                "                                 S.Date_De_Soin, " +
                "                                 S.Type_De_Soin, " +
                "                                 E.Nom_Employe, " +
                "                                 S.Durree_Indisponibilite," +
                "                                 S.Note_Libre," +
                "                                 S.Id_Cheval, " +
                "                                 S.Id_Employe, " +
                "                                 S.Id_Soins" +
                "                           from Soins S join Employe E" +
                "                                   on E.Id_Employe = S.Id_Employe" +
                "                                 join Cheval C" +
                "                                   on C.Id_Cheval = S.Id_Cheval" +
                "                           where E.Id_Employe = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.SoinsToDAl());

        }
        public string NomChevalParEmploye(int id)
        {
            Command command = new Command("select c.Nom_cheval from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();

        }
        public IEnumerable <Cheval> ChevalParEmploye (int id)
        {
            Command command = new Command("Select c.* from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.ChevalToDAL());
        }
        public DateTime DateEntrainementParEmploye(int id)
        {
            Command command = new Command("select ent.Date_Entrainement from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (DateTime)dr["Nom_cheval"]).FirstOrDefault();

        }
        public string ChevalEntrainementAgeParEmploye(int id)
        {
            Command command = new Command("select ent.Nom_cheval from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();

        }
        public string ChevalEntrainementPlatParEmploye(int id)
        {
            Command command = new Command("select ent.Plat from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Plat"]).FirstOrDefault();

        }
        public string ChevalEntrainementObstacleParEmploye(int id)
        {
            Command command = new Command("select ent.Obstacle from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Obstacle"]).FirstOrDefault();

        }
        public string ChevalEntrainementMarcheurParEmploye(int id)
        {
            Command command = new Command("select ent.Marcheur from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Marcheur"]).FirstOrDefault();

        }
        public string ChevalEntrainementPreParEmploye(int id)
        {
            Command command = new Command("select ent.Pre from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Pre"]).FirstOrDefault();

        }
        public string ChevalEntrainementDureeParEmploye(int id)
        {
            Command command = new Command("select ent.Duree from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Duree"]).FirstOrDefault();

        }
        public string ChevalEntrainerParEmploye(int id)
        {
            Command command = new Command("select C.Nom_cheval from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();

        }
        public string ChevalEntrainerSexeParEmploye(int id)
        {
            Command command = new Command("select C.Sexe from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sexe"]).FirstOrDefault();

        }
        public int ChevalEntrainerAgeParEmploye(int id)
        {
            Command command = new Command("select C.Age from Employe e join Participe_Entrainement_cheval_employé PECE on e.Id_Employe = PECE.Id_Employe join Entrainement ENT on PECE.Id_Entrainement = ENT.Id_Entrainement join Cheval C on PECE.Id_Cheval = c.Id_Cheval where e.Id_Employe =@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Age"]).FirstOrDefault();

        }

    }
}

