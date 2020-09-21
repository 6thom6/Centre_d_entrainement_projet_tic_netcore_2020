using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.Models;
using DAL.IRepository;

namespace DAL.Repository
{
    class EntrainementRepository : IEntrainementRepository
    {

        public SqlConnection _connection;

        public EntrainementRepository(SqlConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        public List<Entrainement> GetallEntrainement()
        {
            List<Entrainement> GetallEntrainement = new List<Entrainement>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Entrainement", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallEntrainement.Add(
                        new Entrainement
                        {
                            Id_Entainement = (int)reader["Id_Entainement"],
                            Cheval = (string)reader["Cheval"],
                            Plat = reader["Plat"] == DBNull.Value ? null : (string)reader["Plat"],
                            Obstacle = reader["Obstacle"] == DBNull.Value ? null : (string)reader["Obstacle"],
                            Marcheur = reader["Marcheur"] == DBNull.Value ? null : (string)reader["Marcheur"],
                            Pre = reader["Pre"] == DBNull.Value ? null : (string)reader["Pre"],
                            Duree = reader["Duree"] == DBNull.Value ? null : (string)reader["Duree"],
                            Id_Employe = (int)reader["Id_Employe"],
                        }
                        );
                }

                return GetallEntrainement;
            }

        }
        public Entrainement Get(int idAChercher)
        {
            Entrainement GetEntrainement = new Entrainement();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Entrainement where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Entrainement
                    {
                        Id_Entainement = reader["Id_Entainement"] == DBNull.Value ? 0 : (int)reader["Id_Entainement"],
                        Cheval = reader["Cheval"] == DBNull.Value ? string.Empty : (string)reader["Cheval"],
                        Plat = reader["Plat"] == DBNull.Value ? string.Empty : (string)reader["Plat"],
                        Obstacle = reader["Obstacle"] == DBNull.Value ? string.Empty : (string)reader["Obstacle"],
                        Marcheur = reader["Marcheur"] == DBNull.Value ? string.Empty : (string)reader["Marcheur"],
                        Pre = reader["Pré"] == DBNull.Value ? null : (string)reader["Pre"],
                        Duree = reader["Durée"] == DBNull.Value ? null : (string)reader["Durée"],
                        Id_Employe = reader["Id_Employe"] == DBNull.Value ? 0 : (int)reader["Id_Employe"],

                    };
                     
                }
                return GetEntrainement;
            }
        }
        public void Create(Entrainement NouvelEntrainement)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Entrainement " +
                    "                                       (Cheval,Plat," + //les champs de la table
                                                             "Obstacle,Marcheur," +
                                                             "Pré,Durée, " +
                                                             "Id_Employe)" +
                                                     "VALUES (@Cheval, @Plat," + //les champs a rentrer
                                                             "@Obstacle, @Marcheur, " +
                                                             "@Pre, @Duree, " +
                                                             "@Id_Employe)");

                command.Parameters.AddWithValue("cheval", NouvelEntrainement.Cheval);
                command.Parameters.AddWithValue("plat", NouvelEntrainement.Plat);
                command.Parameters.AddWithValue("obstacle", NouvelEntrainement.Obstacle);
                command.Parameters.AddWithValue("marcheur", NouvelEntrainement.Marcheur);
                command.Parameters.AddWithValue("pre", NouvelEntrainement.Pre);
                command.Parameters.AddWithValue("duree", NouvelEntrainement.Duree);
                command.Parameters.AddWithValue("id_Employe", NouvelEntrainement.Id_Employe);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Update(Entrainement EntrainementAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Entrainement SET Cheval = @cheval, Plat = @plat" +
                    "Obstacle = @obstacle , Marcheur = @obstacle, Pre = @pre , Duree = @duree, Id_Employe = @Id_Employe" +
                    "Where Id_Entainement = @id_entrainement");

                command.Parameters.AddWithValue("id_entrainement", EntrainementAModifier.Id_Entainement);
                command.Parameters.AddWithValue("cheval", EntrainementAModifier.Cheval);
                command.Parameters.AddWithValue("plat", EntrainementAModifier.Plat);
                command.Parameters.AddWithValue("obstacle", EntrainementAModifier.Obstacle);
                command.Parameters.AddWithValue("marcheur", EntrainementAModifier.Marcheur);
                command.Parameters.AddWithValue("pre", EntrainementAModifier.Pre);
                command.Parameters.AddWithValue("duree", EntrainementAModifier.Duree);
                command.Parameters.AddWithValue("id_Employe", EntrainementAModifier.Id_Employe);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {

            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Entrainement where ID = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

    }
}
