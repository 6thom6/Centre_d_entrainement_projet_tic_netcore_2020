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
   public class HistoRipository : IHistoRipository
    {
        private static Connection _connection;

        public HistoRipository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Historique> GetallHistorique()
        {
            Command command = new Command("SELECT * FROM Historique");
            return _connection.ExecuteReader(command, dr => dr.HistoriqueToDal());

        }
        public Historique Get(int id)
        {
            Command command = new Command("SELECT * From Historique where Id_historique = @id");
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, dr => dr.HistoriqueToDal()).SingleOrDefault();

        }
        public int Create(Historique historique)
        {
            Command command = new Command("CreateHistorique", true);
                command.AddParameter("Id_Cheval", historique.Id_Cheval);
                command.AddParameter("Debourage", historique.Debourage);
                command.AddParameter("Pre_Entrainement", historique.Pre_Entrainement);
                command.AddParameter("Entraineur_Precedent", historique.Entraineur_Precedent);
                command.AddParameter("Proprietaire_Precedent", historique.Proprietaire_Precedent);
            return _connection.ExecuteNonQuery(command);

        }
        public int Update(int id, Historique historique)
        {

                Command command = new Command("UPDATE Historique SET Id_Cheval = @Id_Cheval" +
                                                                    "Debourage =  @Debourage, Pre_Entrainement = @Pre_Entrainement," +
                                                                    "Entraineur_Precedent = @entraineur_precedent, Proprietaire_Precedent = @proprietaire_precedent" +
                                                                 "WHERE Id_Historique = @Id_Hitorique");

                command.AddParameter("Id_Hitorique", id);
                command.AddParameter("Id_Cheval", historique.Id_Cheval);
                command.AddParameter("Debourage", historique.Debourage);
                command.AddParameter("Pre_Entrainement", historique.Pre_Entrainement);
                command.AddParameter("Entraineur_Precedent", historique.Entraineur_Precedent);
                command.AddParameter("Proprietaire_Precedent", historique.Proprietaire_Precedent);
            return _connection.ExecuteNonQuery(command);

        }
        public int Delete(int id)
        {
            Command command = new Command("DELETE FROM HISTORIQUE where ID_Historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);
        }
    }
}
