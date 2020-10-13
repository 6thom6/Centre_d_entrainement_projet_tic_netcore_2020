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

        public HistoRipository(): this(_connection) { }
        public IEnumerable<ChevalHistorique> GetallHistorique()
        {
            Command command = new Command("select c.Nom_cheval,c.Pere_cheval,c.Mere_cheval,c.Race,c.Age,c.Sexe,h.Debourage,h.Pre_Entrainement,h.Entraineur_precedent, h.Proprietaire_precedent, h.Elevage from Cheval c join Historique h on c.Id_Cheval = h.Id_Cheval");
            return _connection.ExecuteReader(command, dr => dr.ChevalHistoriqueToDal());

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
                command.AddParameter("Elevage", historique.Elevage);
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
                command.AddParameter("Elevage", historique.Elevage);
            return _connection.ExecuteNonQuery(command);

        }
        public int Delete(int id)
        {
            Command command = new Command("DELETE FROM HISTORIQUE where ID_Historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteNonQuery(command);
        }
        public string GetNomChevalParHisto(int id)
        {
            Command command = new Command(" select c.Nom_cheval from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Nom_cheval"]).FirstOrDefault();
        }
        public string GetNomPereChevalParHisto(int id)
        {
            Command command = new Command(" select c.Pere_cheval from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Pere_cheval"]).FirstOrDefault();
        }
        public string GetNomMereChevalParHisto(int id)
        {
            Command command = new Command(" select c.Mere_cheval from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Mere_cheval"]).FirstOrDefault();
        }
        public string GetRaceChevalParHisto(int id)
        {
            Command command = new Command(" select c.Race from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Race"]).FirstOrDefault();
        }
        public int GetAgeChevalParHisto(int id)
        {
            Command command = new Command(" select c.Age from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (int)dr["Race"]).FirstOrDefault();
        }
        public string GetSexeChevalParHisto(int id)
        {
            Command command = new Command(" select c.Sexe from Historique h join Cheval c on h.Id_Cheval = c.Id_Cheval where Id_historique = @id");
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, dr => (string)dr["Sexe"]).FirstOrDefault();
        }




    }
}
