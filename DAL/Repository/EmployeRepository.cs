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
    class EmployeRepository : IEmployeRepository
    {
        private static Connection _connection;

        public EmployeRepository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Employé> GetallEmploye()
        {
            Command command = new Command("SELECT * FROM Employé");
            return _connection.ExecuteReader(command, dr => dr.EmployéToDal());
        }

        public Employé GetById(int id)
        {
            Command command = new Command("SELECT * FROM Employé where Id_Employe=@id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.EmployéToDal()).SingleOrDefault();

        }
        public int Create(Employé employe)
        {
            Command command = new Command("CreateEmploye", true);
                command.AddParameter("Nom_Employe", employe.Nom_Employe);
                command.AddParameter("Status_Employe", employe.Statut_Employe);
                command.AddParameter("Date_Embauche", employe.Date_Embauche);
            return _connection.ExecuteNonQuery(command);
            
        }
        public int Update(int id, Employé employe)
        {
            

               Command command = new Command("UPDATE Employé " +
                                                     "Nom_Employe = @Nom_Employe, " +
                                                     "Statut_Employe = @Status_Employe, " +
                                                     "Date_Embauche = @Date_Embauche" +
                                                     "where Employé Id_Employé = @Id_Employe");

                command.AddParameter("Id_Employe", id);
                command.AddParameter("Nom_Employe", employe.Nom_Employe);
                command.AddParameter("Status_Employe", employe.Statut_Employe);
                command.AddParameter("Date_Embauche", employe.Date_Embauche);

              return _connection.ExecuteNonQuery(command);

  
        }
        public int Delete(int id)
        {
            Command command = new Command("DELETE FROM Employé where Id_Employe = id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);
        }
        //controleur employe pas fait!
    }
}

