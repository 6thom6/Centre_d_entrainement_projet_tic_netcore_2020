using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;

namespace DAL.Repository
{
    class ProprietaireRepository : IProprietaireRepository
    {
        public SqlConnection _connection;

        public ProprietaireRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        public List<Proprietaire> GetallProprietaire()
        {
            List<Proprietaire> GetallProprietaire = new List<Proprietaire>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Proprietaire", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallProprietaire.Add(
                        new Proprietaire
                        {
                            Id_Proprietaire = (int)reader["Id_Proprietaire"],
                            Nom_Proprietaire = (string)reader["Nom_Proprietaire"],
                            Dernier_Resultats = reader["Dernier_Resultats"] == DBNull.Value ? string.Empty : (string)reader["Dernier_Resultats"],
                            Date_Arrivee = (DateTime)reader["Date_Arrivee"],

                        }
                        );
                }
            }
            _connection.Close();
            return GetallProprietaire;
        }
        public Proprietaire Get(int idAChercher)
        {
            Proprietaire GetProprietaire = new Proprietaire();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Proprietaire where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Proprietaire
                    {
                        Id_Proprietaire = (int)reader["Id_Proprietaire"],
                        Nom_Proprietaire = (string)reader["Nom_Proprietaire"],
                        Dernier_Resultats = reader["Dernier_Resultats"] == DBNull.Value ? null : (string)reader["Dernier_Resultats"],
                        Date_Arrivee = (DateTime)reader["Date_Arrivee"],

                    };
                        
                }
            }
            _connection.Close();
            return GetProprietaire;
        }
        public void Create(Proprietaire NouveauProprietaire)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Proprietaire (Nom_Proprietaire,Effectif," + //les champs de la table
                                                  "Date_Arrivee,Dernier_Resultat)" +
                                                  "VALUES (@nom,effectif," + //les champs a rentrer
                                                  "@date_arrivee, @dernier_resultat)");

                command.Parameters.AddWithValue("nom", NouveauProprietaire.Nom_Proprietaire);
                command.Parameters.AddWithValue("date_arrivee", NouveauProprietaire.Date_Arrivee);
                command.Parameters.AddWithValue("dernier_resultat", NouveauProprietaire.Dernier_Resultats);



                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Update(Proprietaire ProprietaireAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Nom_Proprietaire = @nom" +
                    "Effectif = @effectif, Date_Arrivee = @date_arrivee, Dernier_Resultats = @dernier_resultat" +
                    "WHERE Id_Proprietaire = @id_proprietaire");

                command.Parameters.AddWithValue("id_proprietaire", ProprietaireAModifier.Id_Proprietaire);
                command.Parameters.AddWithValue("nom", ProprietaireAModifier.Nom_Proprietaire);
                command.Parameters.AddWithValue("date_arrivee", ProprietaireAModifier.Date_Arrivee);
                command.Parameters.AddWithValue("dernier_resultat", ProprietaireAModifier.Dernier_Resultats);



                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Proprietaire where ID = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
