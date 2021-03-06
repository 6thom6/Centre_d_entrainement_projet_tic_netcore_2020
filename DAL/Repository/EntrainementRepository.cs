using System;
using System.Collections.Generic;
using DAL.Models;
using DAL.IRepository;
using Tools.Database;
using DAL.Repository.Extensions;
using System.Linq;

namespace DAL.Repository
{
   public class EntrainementRepository : IEntrainementRepository
    {

        private static Connection _connection;

        public EntrainementRepository(Connection connection)
        {
            _connection = connection;
        }
        public EntrainementRepository(): this(_connection) { }
        public IEnumerable<Entrainement> GetallEntrainement()
        {
            Command command = new Command("SELECT * FROM Entrainement");
            return _connection.ExecuteReader(command, dr => dr.EntrainementToDal());

        }
        public Entrainement GetById(int id)
        {
            Command command = new Command("SELECT * FROM Entrainement where Id_Entrainement = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EntrainementToDal()).SingleOrDefault();
        }
        public int Create(Entrainement entrainement)
        {
            Command command = new Command("CreateEntrainement", true);
            command.AddParameter("Plat", entrainement.Plat);
            command.AddParameter("Obstacle", entrainement.Obstacle);
            command.AddParameter("Marcheur", entrainement.Marcheur);
            command.AddParameter("Duree", entrainement.Marcheur);
            command.AddParameter("Pre", entrainement.Pre);
            command.AddParameter("Date_Entrainement", entrainement.Date_Entrainement);

            return (int) _connection.ExecuteScalar(command);

        }
        public int Update(int id, Entrainement entrainement)
        {


                Command command = new Command("UPDATE Entrainement SET  Plat = @Plat," +
                                                                        "Obstacle = @Obstacle , Marcheur = @Marcheur, " +
                                                                        "Pre = @Pre , Duree = @Duree, " +
                                                                        "Date_Entrainement = @Date_Entrainement " +
                                                                    "where Id_Entrainement = @Id_Entrainement");

                command.AddParameter("Plat", entrainement.Plat);
                command.AddParameter("Obstacle", entrainement.Obstacle);
                command.AddParameter("Marcheur", entrainement.Marcheur);
                command.AddParameter("Pre", entrainement.Pre);
                command.AddParameter("Duree", entrainement.Duree);
                command.AddParameter("Date_Entrainement", entrainement.Date_Entrainement);


            return _connection.ExecuteNonQuery(command);


        }
        public int Delete(int id)
        {
            throw new Exception();

        }

        public IEnumerable<EmployeCheval> GetAllEmployeAndChevalByEntrainementId(int id)
        {
            Command command = new Command("SELECT E.*, C.* FROM Participe_Entrainement_cheval_employé pece JOIN Cheval C ON C.Id_Cheval = pece.Id_Cheval JOIN Employe E ON E.Id_Employe = pece.Id_Employe WHERE pece.Id_Entrainement = @Id;");

            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (dr) => dr.EmployeChevalToDAL());
        }
        public IEnumerable<EntrainementEmployeCheval> GetAllEmployeChevalEntrainement()
        {
            Command command = new Command("select * from V_entrainementcomplet");
            return _connection.ExecuteReader(command, (dr) => dr.EntrainementEmployeChevalToDal());
        }

        public IEnumerable<Employe> GetAllEmployeByEntrainementId(int id)
        {
            Command command = new Command("SELECT E.* FROM Participe_Entrainement_cheval_employé " +
                                                    "pece JOIN Employe E ON E.Id_Employe = pece.Id_Employe " +
                                                    "WHERE pece.Id_Entrainement = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EmployeToDal());
               

        }

        public string GetNomChevalParEntrainement(int id)
        {
            Command command = new Command("select c.Nom_cheval from Entrainement e join Participe_Entrainement_cheval_employé PECE on e.Id_Entrainement = PECE.Id_Entrainement join Cheval C on c.Id_Cheval = PECE.Id_Cheval where E.Id_Entrainement = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();
        }
        public string GetEmployeByEntrainementId (int id)
        {
            Command command = new Command("select e.Nom_Employe from Entrainement ent join Participe_Entrainement_cheval_employé PCE on ent.Id_Entrainement = PCE.Id_Entrainement join Employe e on e.Id_Employe = PCE.Id_Entrainement where Id_Cheval = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => (string)dr["Nom_Employe"]).FirstOrDefault();
        }
        public int GetAgeChevalParEntrainement(int id)
        {
            Command command = new Command("select c.Age from Entrainement e join Participe_Entrainement_cheval_employé PECE on e.Id_Entrainement = PECE.Id_Entrainement join Cheval C on c.Id_Cheval = PECE.Id_Cheval where E.Id_Entrainement = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Age"]).FirstOrDefault();
        }
        public string GetSexParEntrainement(int id)
        {
            Command command = new Command("select c.Sexe from Entrainement e join Participe_Entrainement_cheval_employé PECE on e.Id_Entrainement = PECE.Id_Entrainement join Cheval C on c.Id_Cheval = PECE.Id_Cheval where E.Id_Entrainement = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sexe"]).FirstOrDefault();
        }
        public IEnumerable<EntrainementEmployeCheval> entrainementEmployeChevals(int id)
        {
            Command command = new Command("select E.Date_Entrainement, em.Nom_Employe, c.Nom_cheval, c.Age, c.Sexe, E.Plat, e.Obstacle, e.Marcheur, e.Pre, e.Duree from Entrainement E join Participe_Entrainement_cheval_employé PECE on e.Id_Entrainement = PECE.Id_Entrainement join Cheval c on PECE.Id_Cheval = c.Id_Cheval join Employe EM on PECE.Id_Employe = em.Id_Employe where e.Id_Entrainement = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.EntrainementEmployeChevalToDal());
        }

    }
}
