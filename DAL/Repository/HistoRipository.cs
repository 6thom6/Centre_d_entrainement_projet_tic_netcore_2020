using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;

namespace DAL.Repository
{
    class HistoRipository : IHistoRipository
    {
        public SqlConnection _connection;

        public HistoRipository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        public List<Historique> GetallHistorique()
        {
            List<Historique> GetallHistorique = new List<Historique>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Historique", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallHistorique.Add(
                        new Historique
                        {
                            Id_Historique = (int)reader["Id_Historique"],
                            Id_Cheval = (int)reader["Id_Cheval"],
                            Debourrage = reader["Debourrage"] == DBNull.Value ? null : (string)reader["Debourrage"],
                            Pree_Entrainement = reader["Pre-entrainement"] == DBNull.Value ? null : (string)reader["Pre-entrainement"],
                            Entraineur_Precedent = reader["Entraineur_Precedent"] == DBNull.Value ? null : (string)reader["Entraineur_Precedent"],
                            Proprietaire_Precedent = reader["Proprietaire_Precedent"] == DBNull.Value ? null : (string)reader["Proprietaire_Precedent"],

                        }
                        );
                }
            }

            return GetallHistorique;
        }
        public Historique Get(int idAChercher)
        {
            Historique GetHistorique = new Historique();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Historique where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Historique
                    {
                        Id_Historique = (int)reader["Id_Historique"],
                        Id_Cheval = (int)reader["Id_Cheval"],
                        Debourrage = reader["Debourrage"] == DBNull.Value ? null : (string)reader["Debourrage"],
                        Pree_Entrainement = reader["Pre-entrainement"] == DBNull.Value ? null : (string)reader["Pre-entrainement"],
                        Entraineur_Precedent = reader["Entraineur_Precedent"] == DBNull.Value ? null : (string)reader["Entraineur_Precedent"],
                        Proprietaire_Precedent = reader["Proprietaire_Precedent"] == DBNull.Value ? null : (string)reader["Proprietaire_Precedent"],

                    };
                        
                }
                
            }
            _connection.Close();
            return GetHistorique;

        }
        public void Create(Historique NouvelHistorique)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Historique (Id_Cheval,Debourrage," + //les champs de la table
                                                     "Pree_Entrainement," +
                                                     "Entraineur_Precedent,Proprietaire_Precedent)" +
                                                     "VALUES (@id_cheval,@debourrage," + //les champs a rentrer
                                                     "@pre_entrainement, @entraineur_precedent, " +
                                                     "@proprietaire_precedent)");

                command.Parameters.AddWithValue("id_cheval", NouvelHistorique.Id_Cheval);
                command.Parameters.AddWithValue("debourrage", NouvelHistorique.Debourrage);
                command.Parameters.AddWithValue("pre_entrainement", NouvelHistorique.Pree_Entrainement);
                command.Parameters.AddWithValue("entraineur_precedent", NouvelHistorique.Entraineur_Precedent);
                command.Parameters.AddWithValue("proprietaire_precedent", NouvelHistorique.Proprietaire_Precedent);


                command.ExecuteNonQuery();



                _connection.Close();

            }
        }
        public void Update(Historique HistoriqueAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Historique SET Id_Cheval = @id_cheval" +
                    "Débourrage =  @debourrage, Pree_Entrainement = @pre_entrainement" +
                    "Entraineur_Precedent = @entraineur_precedent, Proprietaire_Precedent = @proprietaire_precedent" +
                             "WHERE Id_Historique = @id_hitorique");

                command.Parameters.AddWithValue("id_hitorique", HistoriqueAModifier.Id_Historique);
                command.Parameters.AddWithValue("id_cheval", HistoriqueAModifier.Id_Cheval);
                command.Parameters.AddWithValue("debourrage", HistoriqueAModifier.Debourrage);
                command.Parameters.AddWithValue("pre_entrainement", HistoriqueAModifier.Pree_Entrainement);
                command.Parameters.AddWithValue("entraineur_precedent", HistoriqueAModifier.Entraineur_Precedent);
                command.Parameters.AddWithValue("proprietaire_precedent", HistoriqueAModifier.Proprietaire_Precedent);


                command.ExecuteNonQuery();



                _connection.Close();
            }

        }
        public void Delete(int idADelete)
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Historique where ID = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
