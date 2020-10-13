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
    public class SoinsRepository : ISoinsRepository
    {
        private static Connection _connection;

        public SoinsRepository(Connection connection)
        {
            _connection = connection;
        }
        public SoinsRepository(): this(_connection)
        {

        }

        public IEnumerable<SoinsCheval> GetallSoins()
        {
            Command command = new Command("select C.Nom_cheval, s.Type_De_Soin, s.Date_De_Soin, s.Durree_Indisponibilite, c.Age, c.Sexe, s.Marechal_Derniere_Visite, s.Vermifuge, s.Alimentation, s.Complement_Alimentation from Cheval c join Soins s on c.Id_Cheval = s.Id_Cheval");
            return _connection.ExecuteReader(command, dr => dr.SoinsChevalToDal());

        }
        public Soins GetById(int id)
        {
            Command command = new Command("SELECT * FROM SOINS where Id_Soins = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.SoinsToDAl()).SingleOrDefault();
        }
        public int Create(Soins soin)
        {
            Command command = new Command("CreateSoins", true);
                command.AddParameter("id_cheval", soin.Id_Cheval);
                command.AddParameter("id_employe", soin.Id_Employe);
                command.AddParameter("alimentation", soin.Alimentation);
                command.AddParameter("complement_alimentation", soin.Complement_Alimentation);
                command.AddParameter("note_libre", soin.Note_Libre);
                command.AddParameter("marechal_Derniere_Visite", soin.Marechal_Derniere_Visite);
                command.AddParameter("Vermifuge", soin.Vermifuge);
                command.AddParameter("Type_De_Soin", soin.Type_De_Soin);
                command.AddParameter("Durree_indisponibilite", soin.Durree_Indisponibilite);
                command.AddParameter("Date_De_Soin", soin.Date_De_Soin);

            return _connection.ExecuteNonQuery(command);

        }
        public int Update(int id, Soins soin)
        {

                Command command = new Command("UPDATE Soins SET Id_Cheval = @Id_Cheval," +
                                                               "Id_Employe = @Id_Employe, " +
                                                               "Alimentation = @Alimentation," +
                                                               "Complement_Alimentation = @Complement_Alimentation, " +
                                                               "Note_Libre = @Note_Libre, " +
                                                               "Marechal_Derniere_Visite = @Marechal_Derniere_Visite, " +
                                                               "Vermifuge = @Vermifuge, " +
                                                               "Type_De_Soin = @Type_De_Soin," +
                                                               "Durree_Indisponibilite = @Durree_Indisponibilite," +
                                                               "Date_De_Soin = @Date_De_Soin " +
                                                                 "WHERE Id_Soins = @id_soins ");

                command.AddParameter("Id_Soins",id);
                command.AddParameter("Id_Cheval", soin.Id_Cheval);
                command.AddParameter("Id_Employe", soin.Id_Employe);
                command.AddParameter("Alimentation", soin.Alimentation);
                command.AddParameter("Complement_Alimentation", soin.Complement_Alimentation);
                command.AddParameter("Note_Libre", soin.Note_Libre);
                command.AddParameter("Marechal_Derniere_Visite", soin.Marechal_Derniere_Visite);
                command.AddParameter("Vermifuge", soin.Vermifuge);
                command.AddParameter("type_De_Soin", soin.Type_De_Soin);
                command.AddParameter("Durree_Indisponibilite", soin.Durree_Indisponibilite);
                command.AddParameter("Date_De_Soin", soin.Date_De_Soin);

            return _connection.ExecuteNonQuery(command);


            
        }
        public int Delete(int id)
        {
            Command command = new Command("DELETE FROM SOINS where Id_Soins = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);

        }

        public string GetNomCheval (int id)
        {
            Command command = new Command("SELECT c.Nom_cheval FROM Soins s JOIN Cheval c ON s.Id_Cheval = c.Id_Cheval WHERE s.Id_Soins = @Id; ");
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (dr) => (string)dr["Nom_cheval"]).FirstOrDefault();
        }
        public string GetNomEmploye(int id)
        {
            Command command = new Command(" SELECT c.Nom_Employe FROM Soins s JOIN Employe c ON s.Id_Employe = c.Id_Employe WHERE s.Id_Soins = @Id; ");
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (dr)=>(string)dr["Nom_Employe"]).FirstOrDefault();
        }
        public string GetStatutsEmploye(int id)
        {
            Command command = new Command(" SELECT c.Statuts_Employe FROM Soins s JOIN Employe c ON s.Id_Employe = c.Id_Employe WHERE s.Id_Soins = @Id; ");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, (dr) => (string)dr["Statuts_Employe"]).FirstOrDefault();

        }
        public string GetSexCheval (int id)
        {
            Command command = new Command(" SELECT c.Sexe FROM Soins s JOIN Cheval c ON s.Id_Cheval = c.Id_Cheval HERE s.Id_Soins = @id; ");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sexe"]).FirstOrDefault();
        }
        public int GetAgeCheval(int id)
        {
            Command command = new Command(" SELECT c.Age FROM Soins s JOIN Cheval c ON s.Id_Cheval = c.Id_Cheval HERE s.Id_Soins = @id; ");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int) dr["Age"]).FirstOrDefault();
        }


    }
}
