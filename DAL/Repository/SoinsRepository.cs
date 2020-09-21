using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.IRepository;
using Tools.Database;

namespace DAL.Repository
{
    class SoinsRepository : ISoinsRepository
    {
        private static Connection _connection;

        public SoinsRepository(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Soins> GetallSoins()
        {


        }
        public Soins Get(int idAChercher)
        {
            Soins GetSoins = new Soins();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Soins where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Soins
                    {
                        Id_Soins = reader["Id_Soins"] == DBNull.Value ? null : (int?)reader["Id_Soins"],
                        Id_Cheval = reader["Id_Cheval"] == DBNull.Value ? 0 : (int)reader["Id_Cheval"],
                        Id_Employe = reader["Id_Employe"] == DBNull.Value ? null : (int?)reader["Id_Employe"],
                        Alimentation = (string)reader["Alimentation"],
                        Complement_Alimentation = reader["Complement_Alimentation"] == DBNull.Value ? null : (string)reader["Complement_Alimentation"],
                        Note_Libre = reader["Note_Libre"] == DBNull.Value ? null : (string)reader["Note_Libre"],
                        Marechal = reader["Marechal"] == DBNull.Value ? null : (DateTime?)reader["Marechal"],
                        Vermifuge = reader["Vermifuge"] == DBNull.Value ? null : (DateTime?)reader["Vermifuge"],
                        Type_de_soin = reader["Type_de_soin"] == DBNull.Value ? null : (string)reader["Type_de_soin"],
                        durree_indisponibilite = reader["durree_indisponibilite"] == DBNull.Value ? null : (string)reader["durree_indisponibilite"],
                        date_de_soin = reader["date_de_soin"] == DBNull.Value ? null : (DateTime?)reader["date_de_soin"]

                    };
                        
                }
            }
            _connection.Close();
            return GetSoins;
        }
        public void Create(Soins NouveauSoins)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Soins (Id_Cheval,Id_Employe," + //les champs de la table
                                                  "Alimentation,Complement_Alimentation," +
                                                  "Note_Libre,Marechal,Vermifuge, Type_de_soin, durree_indisponibilite, date_de_soin)" +
                                                  "VALUES (@id_cheval,@id_employe," + //les champs a rentrer
                                                  "@alimentation, @complement_alimentation, " +
                                                  "@note_libre, @marechal, @vermifuge, @type_de_soin,@ Durree_indisponibilite,@Date_de_soin)");
         
                command.Parameters.AddWithValue("id_cheval", NouveauSoins.Id_Cheval);
                command.Parameters.AddWithValue("id_employe", NouveauSoins.Id_Employe);
                command.Parameters.AddWithValue("alimentation", NouveauSoins.Alimentation);
                command.Parameters.AddWithValue("complement_alimentation", NouveauSoins.Complement_Alimentation);
                command.Parameters.AddWithValue("note_libre", NouveauSoins.Note_Libre);
                command.Parameters.AddWithValue("marechal", NouveauSoins.Marechal);
                command.Parameters.AddWithValue("vermifuge", NouveauSoins.Vermifuge);
                command.Parameters.AddWithValue("type_de_soin", NouveauSoins.Type_de_soin);
                command.Parameters.AddWithValue("Durree_indisponibilite", NouveauSoins.durree_indisponibilite);
                command.Parameters.AddWithValue("Date_de_soin", NouveauSoins.date_de_soin);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Update(Soins SoinsAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Soins SET Id_Cheval = @id_cheval" +
                    "Id_Employe = @id_employe, Alimentation =@alimentation,Complement_Alimentation = @ complement_alimentation, " +
                    "Note_Libre = @note_libre, Marechal = @marechal, Vermifuge = @vermifuge, Type_de_soin = @type_de_soin," +
                    "durree_indisponibilite=@durree_indisponibilite,date_de_soin=@date_de_soin" +
                    "WHERE Id_Soins = @id_soins ");

                command.Parameters.AddWithValue("id_soins", SoinsAModifier.Id_Soins);
                command.Parameters.AddWithValue("id_cheval", SoinsAModifier.Id_Cheval);
                command.Parameters.AddWithValue("id_employe", SoinsAModifier.Id_Employe);
                command.Parameters.AddWithValue("alimentation", SoinsAModifier.Alimentation);
                command.Parameters.AddWithValue("complement_alimentation", SoinsAModifier.Complement_Alimentation);
                command.Parameters.AddWithValue("note_libre", SoinsAModifier.Note_Libre);
                command.Parameters.AddWithValue("marechal", SoinsAModifier.Marechal);
                command.Parameters.AddWithValue("vermifuge", SoinsAModifier.Vermifuge);
                command.Parameters.AddWithValue("type_de_soin", SoinsAModifier.Type_de_soin);
                command.Parameters.AddWithValue("durrée_indisponibilité", SoinsAModifier.durree_indisponibilite);
                command.Parameters.AddWithValue("date_de_soin", SoinsAModifier.date_de_soin);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Soins where ID = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

    }
}
