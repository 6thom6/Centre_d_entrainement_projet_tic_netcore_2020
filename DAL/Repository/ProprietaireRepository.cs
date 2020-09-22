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

        public ProprietaireRepository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Proprietaire> GetallProprietaire()
        {
            Command command = new Command("SELECT * FROM Proprietaire");
            return _connection.ExecuteReader(command, dr => dr.ProprietaireToDal());
        }
        public Proprietaire Get(int id)
        {
            Command command = new Command("SELECT * FROM Proprietaire where Id_Proprietaire = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => dr.ProprietaireToDal()).SingleOrDefault();
        }
        public int Create(Proprietaire proprietaire)
        {
            Command command = new Command("CreateProprietaire", true);
                  command.AddParameter("Nom_Proprietaire", proprietaire.Nom_Proprietaire);
                command.AddParameter("Date_Arrivee", proprietaire.Date_Arrivee);
                command.AddParameter("Dernier_Resultat", proprietaire.Dernier_Resultat);

            return _connection.ExecuteNonQuery(command);
        }
        public int Update(int id, Proprietaire proprietaire)
        {



                Command command = new Command ("UPDATE Proprietaire SET Nom_Proprietaire = @Nom_Proprietaire, " +
                                                                        "Date_Arrivee = @Date_Arrivee, " +
                                                                        "Dernier_Resultat = @Dernier_Resultat " +
                                                                        "WHERE Id_Proprietaire = @Id_Proprietaire");

                command.AddParameter("Id_Proprietaire", id);
                command.AddParameter("Nom_Proprietaire", proprietaire.Nom_Proprietaire);
                command.AddParameter("Date_Arrivee", proprietaire.Date_Arrivee);
                command.AddParameter("Dernier_Resultat", proprietaire.Dernier_Resultat);

            return _connection.ExecuteNonQuery(command);

            }
        
        public int Delete(int id)
        {

            throw new Exception();
        //Command command = new Command("DELETE FROM Proprietaire where Id_Proprietaire = @id");
        //command.AddParameter("id", id);

        //    return _connection.ExecuteNonQuery(command);
        }
    }
}
