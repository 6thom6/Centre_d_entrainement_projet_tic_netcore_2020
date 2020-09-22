using DAL.Models;
using System.Collections.Generic;
using DAL.IRepository;
using Tools.Database;
using DAL.Repository.Extensions;
using System.Linq;

namespace DAL.Repository
{
    public class ChevalRepository : IChevalRepository
    {
        private static Connection _connection;

        public ChevalRepository(Connection connection)
        {
            _connection = connection;
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

        public int Create(Cheval cheval)
        {
            Command command = new Command("CreateCheval", true);
            command.AddParameter("Nom_Cheval", cheval.NomCheval);
            command.AddParameter("Pere_Cheval", cheval.PereCheval);
            command.AddParameter("Mere_Cheval", cheval.MereCheval);
            command.AddParameter("Sortie_Provisoire", cheval.SortieProvisoire);
            command.AddParameter("Raison_Sortie", cheval.RaisonSortie);
            command.AddParameter("Id_Proprietaire", cheval.IdProprietaire);
            command.AddParameter("Id_Soins", cheval.IdSoins);
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
            command.AddParameter("Id_proprietaire", cheval.IdProprietaire);
            command.AddParameter("Id_soins", cheval.IdSoins);
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
            Command command = new Command("SELECT P.Nom_Proprietaire" +
                "                          FROM Cheval C JOIN Proprietaire P" +
                "                               ON C.Id_Proprietaire = P.Id_Proprietaire" +
                "                           WHERE C.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.ProprietaireToDal()).SingleOrDefault();
        }

        public IEnumerable<Entrainement> GetEntrainements(int id)
        {
            Command command = new Command("SELECT C.Nom_cheval," +
                "                                 E.Plat," +
                "                                 E.Obstacle," +
                "                                 E.Marcheur," +
                "                                 E.Duree," +
                "                                 E.Pre " +
                "                           FROM Cheval C JOIN mym_Cheval_Entrainement CE " +
                "                                   ON C.Id_Cheval = CE.MYM_ChevaliId_Cheval " +
                "                                JOIN Entrainement E " +
                "                                   ON CE.MYM_Entrainementid_Entrainement = E.Id_Entrainement " +
                "                           WHERE C.Id_Cheval = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EntrainementToDal());
        }
    }
}
