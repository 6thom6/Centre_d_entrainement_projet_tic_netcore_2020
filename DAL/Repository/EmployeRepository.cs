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
        
    }
}

