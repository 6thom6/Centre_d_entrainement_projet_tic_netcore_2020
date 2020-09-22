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
            command.AddParameter("Id_Employe", entrainement.Id_Employe);
            command.AddParameter("Cheval", entrainement.Cheval);
            command.AddParameter("Plat", entrainement.Plat);
            command.AddParameter("Obstacle", entrainement.Obstacle);
            command.AddParameter("Marcheur", entrainement.Marcheur);
            command.AddParameter("Duree", entrainement.Marcheur);
            command.AddParameter("Pre", entrainement.Pre);
            command.AddParameter("Date_Entrainement", entrainement.Date_Entrainement);

            return _connection.ExecuteNonQuery(command);

        }
        public int Update(int id, Entrainement entrainement)
        {


                Command command = new Command("UPDATE Entrainement SET Cheval = @Cheval, Plat = @Plat," +
                                                                     "Obstacle = @Obstacle , Marcheur = @Marcheur, " +
                                                                     "Pre = @Pre , Duree = @Duree, " +
                                                                     "Id_Employe = @Id_Employe," +
                                                                     "Date_Entrainement = @Date_Entrainement " +
                    "where Id_Entrainement = @Id_Entrainement");

                command.AddParameter("Id_entrainement", id);
                command.AddParameter("Cheval", entrainement.Cheval);
                command.AddParameter("Plat", entrainement.Plat);
                command.AddParameter("Obstacle", entrainement.Obstacle);
                command.AddParameter("Marcheur", entrainement.Marcheur);
                command.AddParameter("Pre", entrainement.Pre);
                command.AddParameter("Duree", entrainement.Duree);
                command.AddParameter("Id_Employe", entrainement.Id_Employe);
                command.AddParameter("Date_Entrainement", entrainement.Date_Entrainement);


            return _connection.ExecuteNonQuery(command);


        }
        public int Delete(int id)
        {
            throw new Exception();

        }


    }
}
